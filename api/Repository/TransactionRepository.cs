using api.Data;
using api.Dtos.Transactions;
using api.Enum;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public TransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        #region public methods

        /// <summary>
        /// Retrieves a list of transactions for the current user, filtered by active status, operation date range, and pending state.
        /// </summary>
        /// <returns>A list of TransactionDto objects representing the retrieved transactions.</returns>
        /// <exception cref="NotFoundException">Thrown when no transactions are found for the specified user.</exception>
        public async Task<List<TransactionDto>> GetAsync()
        {
            var transactions = await _context.Transactions
                .Where(t => (t.OperationDate >= DateTime.Now.Date && t.OperationDate <= DateTime.Now.Date.AddMonths(1)) || (t.State==(int)TransactionState.Pending && t.OperationDate <= DateTime.Now.Date))
                .OrderBy(t => t.OperationDate)
                .ToListAsync();

            // Check if any transactions were found
            if (transactions == null || !transactions.Any())
            {
                throw new NotFoundException("No transactions found for the specified user");
            }

            // Create a new list of TransactionDto objects and populate it with data from the retrieved transactions
            var transactionDtos = transactions.Select(transaction => new TransactionDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                State = transaction.State,
                StateDesc = transaction.State == (int)TransactionState.Pending ? "Pending" : "Finished",
                OperationDate = transaction.OperationDate,
                Amount = transaction.Amount,
                SourceAccountOrCardCode = GetAccountOrCardCode(transaction.SourceAccountOrCardCode),
                DestinationAccountOrCardCode = GetAccountOrCardCode(transaction.DestinationAccountOrCardCode),
                FileBytes = transaction.Attachment,
                FileName = string.IsNullOrEmpty(transaction.FileName) ? "File" : transaction.FileName,
                ContentType = transaction.Attachment != null ? ByteArrayToFormFileExtensions.GetContentTypeFromExtension(ByteArrayToFormFileExtensions.InferFileExtension(transaction.Attachment)) : string.Empty
            }).ToList();

            return transactionDtos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="ignoreRules"></param>
        /// <returns></returns>
        public async Task<Transaction> CreateAsync(Transaction transaction, bool? ignoreRules)
        {
            try
            {
                if (ignoreRules.HasValue && ignoreRules.Value)
                    await InsertIgnoringRules(transaction);
                else
                    await Insert(transaction);

                return transaction;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Transaction> ConfirmTransactionAsync(int id)
        {
            Transaction? transaction
                =  await _context
                    .Transactions
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (transaction == null)
            {
                throw new Exception("Transaction not found!");
            }

            if (transaction.CreditId.HasValue)
                await HandleWithCredits(transaction);
            else
                await HandleWithNormalTransactions(transaction);

            return transaction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _context.Transactions.FirstAsync(t => t.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateTransactionDto"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Transaction> UpdateAsync(int id, UpdateTransactionDto updateTransactionDto)
        {
            Transaction? transaction = await _context.Transactions.FindAsync(id);

            if (transaction is null)

                throw new NotFoundException("Transaction does not exist!");

            bool isChanged = false;

            //Only update for a newer file. 
            if (updateTransactionDto.File != null)
            {
                isChanged = true;
                byte[]? fileContent = null;
                using (var memoryStream = new MemoryStream())
                {
                    if (updateTransactionDto.File is not null)
                    {
                        await updateTransactionDto.File.CopyToAsync(memoryStream);
                        fileContent = memoryStream.ToArray();
                    }
                }

                if (transaction.Attachment != fileContent && transaction.FileName != updateTransactionDto.FileName)
                {
                    transaction.Attachment = fileContent;
                    transaction.FileName = updateTransactionDto.FileName;
                }
                else
                {
                    isChanged = false;
                }
            }

            if (transaction.Amount != updateTransactionDto.Amount)
            {
                transaction.Amount = updateTransactionDto.Amount;
                isChanged = true;
            }
            if (transaction.CreditId != updateTransactionDto.CreditId)
            {
                transaction.CreditId = updateTransactionDto.CreditId;
                isChanged = true;
            }
            if (transaction.Description != updateTransactionDto.Description)
            {
                transaction.Description = updateTransactionDto.Description;
                isChanged = true;
            }

            if (transaction.EarningId != updateTransactionDto.EarningId)
            {
                transaction.EarningId = updateTransactionDto.EarningId;
                isChanged = true;
            }

            if (transaction.ExpenseId != updateTransactionDto.ExpenseId)
            {
                transaction.ExpenseId = updateTransactionDto.ExpenseId;
                isChanged = true;
            }

            if (transaction.SubCategoryId != updateTransactionDto.SubCategoryId)
            {
                transaction.SubCategoryId = updateTransactionDto.SubCategoryId;
                isChanged = true;
            }

            if (transaction.UserId != updateTransactionDto.UserId)
            {
                transaction.UserId = updateTransactionDto.UserId;
                isChanged = true;
            }

            if (transaction.OperationDate != updateTransactionDto.OperationDate)
            {
                transaction.OperationDate = updateTransactionDto.OperationDate;
                isChanged = true;
            }

            if (transaction.SourceAccountOrCardCode != updateTransactionDto.SourceAccountOrCardCode)
            {
                transaction.SourceAccountOrCardCode = updateTransactionDto.SourceAccountOrCardCode;
                isChanged = true;
            }

            if (transaction.DestinationAccountOrCardCode != updateTransactionDto.DestinationAccountOrCardCode)
            {
                transaction.DestinationAccountOrCardCode = updateTransactionDto.DestinationAccountOrCardCode;
                isChanged = true;
            }

            if (isChanged)
            {
                transaction.UpdatedDate = DateTime.UtcNow;
                try
                {
                    _context.Entry(transaction).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    if ((transaction.State != updateTransactionDto.State) && updateTransactionDto.State == (int)TransactionState.Finished)
                    {
                        transaction.State = (int)TransactionState.Finished;
                        _context.Entry(transaction).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        await DebtMoney(transaction);
                        await _context.SaveChangesAsync();

                        await CreditMoney(transaction);
                        await _context.SaveChangesAsync();

                        await UpdateFinanceGoal(transaction);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return transaction;
        }

        /// <summary>
        /// Remove one transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaction> DeleteAsync(int id)
        {
            Transaction transaction = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transaction!);
            await _context.SaveChangesAsync();

            return transaction!;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Retrieves the description of a bank account, gift card, credit, or credit card based on the provided code.
        /// </summary>
        /// <param name="accountOrCardCode">The code of the bank account, gift card, credit, or credit card.</param>
        /// <returns>The description of the corresponding bank account, gift card, credit, or credit card, or an empty string if not found.</returns>
        private string GetAccountOrCardCode(string? accountOrCardCode)
        {
            if (string.IsNullOrWhiteSpace(accountOrCardCode))
            {
                return string.Empty;
            }
            else
            {
                // Check if the code matches a bank account
                BankAccount? bankAccount = _context.BankAccounts.FirstOrDefault(x => x.Code == accountOrCardCode);
                if (bankAccount != null)
                {
                    return bankAccount.Description!;
                }

                // Check if the code matches a gift card
                GiftCard? giftCard = _context.GiftCards.FirstOrDefault(x => x.Code == accountOrCardCode);
                if (giftCard != null)
                {
                    return giftCard.Description!;
                }

                // Check if the code matches a credit
                Credit? credit = _context.Credits.FirstOrDefault(x => x.Code == accountOrCardCode);
                if (credit != null)
                {
                    return credit.Description!;
                }

                // Check if the code matches a gift card
                DebitCard? debitCard = _context.DebitCards.FirstOrDefault(x => x.Code == accountOrCardCode);
                if (debitCard != null)
                {
                    return debitCard.Description!;
                }

                // Check if the code matches a credit card
                CreditCard? creditCard = _context.CreditCards.FirstOrDefault(x => x.Code == accountOrCardCode);
                if (creditCard != null)
                {
                    return creditCard.Description!;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <exception cref="Exception"></exception>
        private async Task HandleWithCredits(Transaction transaction)
        {
            Credit? credit = await _context.Credits.FindAsync(transaction.CreditId);

            if (credit == null)
            {
                throw new Exception("Credit not found");
            }

            if (string.IsNullOrWhiteSpace(transaction.SourceAccountOrCardCode))
            {
                throw new Exception("Source account or card not provided");
            }

            CreditCard? sourceCreditCard = await _context.CreditCards.FirstOrDefaultAsync(x => x.Code.ToLower() == transaction.SourceAccountOrCardCode.ToLower());
            BankAccount? sourceBankAccount = await _context.BankAccounts.FirstOrDefaultAsync(x => x.Code.ToLower() == transaction.SourceAccountOrCardCode.ToLower());

            if (sourceCreditCard == null && sourceBankAccount == null)
            {
                throw new Exception("Source account not found");
            }

            try
            {
                if (sourceCreditCard != null)
                {
                    sourceCreditCard.Balance -= transaction.Amount;
                    sourceCreditCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(sourceCreditCard).State = EntityState.Modified;
                }
                else if (sourceBankAccount != null)
                {
                    sourceBankAccount.Balance -= transaction.Amount;
                    sourceBankAccount.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(sourceBankAccount).State = EntityState.Modified;
                }

                credit.DebtCapital = credit.DebtCapital + (credit.DebtCapital * (credit.TAN / 100 / 12)) - credit.Installment;

                credit.UpdatedDate = DateTime.UtcNow;
                transaction.UpdatedDate = DateTime.UtcNow;
                transaction.State = (int)TransactionState.Finished;
                _context.Entry(credit).State = EntityState.Modified;
                _context.Entry(transaction).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task HandleWithNormalTransactions(Transaction transaction)
        {
            CreditCard? sourceCreditCard = _context.CreditCards.FirstOrDefault(x => x.Code.ToUpper() == transaction.SourceAccountOrCardCode!.ToUpper());
            BankAccount? sourceBankAccount = _context.BankAccounts.FirstOrDefault(x => x.Code.ToUpper() == transaction.SourceAccountOrCardCode!.ToUpper());

            CreditCard? destinationCreditCard = _context.CreditCards.FirstOrDefault(x => x.Code.ToUpper() == transaction.DestinationAccountOrCardCode!.ToUpper());
            BankAccount? destinationBankAccount = _context.BankAccounts.FirstOrDefault(x => x.Code.ToUpper() == transaction.DestinationAccountOrCardCode!.ToUpper());

            if (sourceCreditCard != null)
            {
                sourceCreditCard.UpdatedDate = DateTime.UtcNow;
                sourceCreditCard.Balance = -transaction.Amount;
                _context.Entry(sourceCreditCard).State = EntityState.Modified;
            }
            else if (sourceBankAccount != null)
            {
                sourceBankAccount.UpdatedDate = DateTime.UtcNow;
                sourceBankAccount.Balance = -transaction.Amount;
                _context.Entry(sourceBankAccount).State = EntityState.Modified;
            }

            if (destinationCreditCard != null)
            {
                destinationCreditCard.UpdatedDate = DateTime.UtcNow;
                destinationCreditCard.Balance = -transaction.Amount;
                _context.Entry(destinationCreditCard).State = EntityState.Modified;
            }
            else if (destinationBankAccount != null && destinationBankAccount.Code != "BankinterCH")
            {
                destinationBankAccount.UpdatedDate = DateTime.UtcNow;
                destinationBankAccount.Balance = -transaction.Amount;
                _context.Entry(destinationBankAccount).State = EntityState.Modified;
            }

            transaction.State = (int)TransactionState.Finished;
            transaction.UpdatedDate = DateTime.Now;
            _context.Entry(transaction).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task Insert(Transaction transaction)
        {
            using var trans = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                if (transaction.State == (int)TransactionState.Finished)
                {
                    await DebtMoney(transaction);
                    await _context.SaveChangesAsync();

                    await CreditMoney(transaction);
                    await _context.SaveChangesAsync();

                    await UpdateFinanceGoal(transaction);
                    await _context.SaveChangesAsync();
                }

                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task DebtMoney(Transaction transaction)
        {
            if (!string.IsNullOrWhiteSpace(transaction.SourceAccountOrCardCode))
            {
                DebitCard? debitCard = await _context
                    .DebitCards
                    .FirstOrDefaultAsync(x => x.Code == transaction.SourceAccountOrCardCode
                    && x.UserId == transaction.UserId
                    && x.IsActive);
                if (debitCard != null)
                {
                    debitCard.Balance -= transaction.Amount;
                    debitCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(debitCard).State = EntityState.Modified;
                }

                GiftCard? giftCard = await _context
                .GiftCards
                .FirstOrDefaultAsync(x => x.Code == transaction.SourceAccountOrCardCode
                && x.UserId == transaction.UserId
                && x.IsActive);
                if (giftCard != null)
                {
                    giftCard.Balance -= transaction.Amount;
                    giftCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(giftCard).State = EntityState.Modified;
                }

                CreditCard? crebitCard = await _context
                   .CreditCards
                   .FirstOrDefaultAsync(x => x.Code == transaction.SourceAccountOrCardCode
                   && x.UserId == transaction.UserId
                   && x.IsActive);
                if (crebitCard != null)
                {
                    crebitCard.Balance -= transaction.Amount;
                    crebitCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(crebitCard).State = EntityState.Modified;
                }

                BankAccount? bankAccount = await _context
                   .BankAccounts
                   .FirstOrDefaultAsync(x => x.Code == transaction.SourceAccountOrCardCode
                   && x.UserId == transaction.UserId
                   && x.IsActive);
                if (bankAccount != null)
                {
                    bankAccount.UpdatedDate = DateTime.UtcNow;
                    bankAccount.Balance -= transaction.Amount;
                    _context.Entry(bankAccount).State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task CreditMoney(Transaction transaction)
        {
            if (!string.IsNullOrWhiteSpace(transaction.Description))
            {
                DebitCard? debitCard = await _context
                    .DebitCards
                    .FirstOrDefaultAsync(x => x.Code == transaction.DestinationAccountOrCardCode
                    && x.UserId == transaction.UserId
                    && x.IsActive);
                if (debitCard != null)
                {
                    debitCard.Balance += transaction.Amount;
                    debitCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(debitCard).State = EntityState.Modified;
                }

                CreditCard? crebitCard = await _context
                   .CreditCards
                   .FirstOrDefaultAsync(x => x.Code == transaction.DestinationAccountOrCardCode
                   && x.UserId == transaction.UserId
                   && x.IsActive);
                if (crebitCard != null)
                {
                    crebitCard.Balance += transaction.Amount;
                    crebitCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(crebitCard).State = EntityState.Modified;
                }

                GiftCard? giftCard = await _context
                 .GiftCards
                 .FirstOrDefaultAsync(x => x.Code == transaction.DestinationAccountOrCardCode
                 && x.UserId == transaction.UserId
                 && x.IsActive);
                if (giftCard != null)
                {
                    giftCard.Balance += transaction.Amount;
                    giftCard.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(giftCard).State = EntityState.Modified;
                }

                BankAccount? bankAccount = await _context
                   .BankAccounts
                   .FirstOrDefaultAsync(x => x.Code == transaction.DestinationAccountOrCardCode
                   && x.UserId == transaction.UserId
                   && x.IsActive);
                if (bankAccount != null)
                {
                    bankAccount.Balance += transaction.Amount;
                    bankAccount.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(bankAccount).State = EntityState.Modified;
                }

                Credit? credit = await _context
                 .Credits
                 .FirstOrDefaultAsync(x => x.Code == transaction.DestinationAccountOrCardCode
                 && x.UserId == transaction.UserId
                 && x.IsActive);
                if (credit != null)
                {
                    credit.DebtCapital = credit.DebtCapital + (credit.DebtCapital * (credit.TAN / 100 / 12)) - transaction.Amount;
                    credit.UpdatedDate = DateTime.UtcNow;
                    if(credit.DebtCapital==0)
                    {
                        credit.IsActive = false;
                    }
                    _context.Entry(credit).State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task UpdateFinanceGoal(Transaction transaction)
        {
            FinanceGoal? financeGoal = await _context
                .FinanceGoals
                .FirstOrDefaultAsync(x => x.IsActive
                    && x.UserId == transaction.UserId);

            if (financeGoal != null)
            {
                financeGoal.UpdatedDate = DateTime.UtcNow;

                decimal bankDebpts = _context.BankAccounts
                    .Where(x => x.IsActive
                        && x.UserId == transaction.UserId
                        && x.Code != "BankinterCH")
                    .Sum(x => x.Balance);

                if (bankDebpts < 0)
                    bankDebpts = bankDebpts * -1;

                decimal creditsDebpts = _context.Credits
                     .Where(x => x.IsActive
                        && x.UserId == transaction.UserId)
                     .Sum(x => x.DebtCapital);

                decimal creditCardsDebpts = _context.CreditCards
                    .Where(x => x.IsActive
                        && x.UserId == transaction.UserId)
                    .Sum(x => x.Plafon - x.Balance);

                financeGoal.CurrentDebtAmount = bankDebpts + creditsDebpts + creditCardsDebpts;
                financeGoal.UpdatedDate = DateTime.UtcNow;
                _context.Entry(financeGoal).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private async Task InsertIgnoringRules(Transaction transaction)
        {
            transaction.State = (int)TransactionState.Pending;
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        #endregion

    }
}