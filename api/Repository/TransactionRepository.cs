using api.Data;
using api.Dtos.BankAccounts;
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

        public async Task<Transaction> CreateAsync(Transaction transaction, bool ignoreRules)
        {
            try
            {
                if (ignoreRules)
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

        public async Task<Transaction> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionDto> GetByCodeId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> UpdateAsync(int id, UpdateTransactionDto updateTransactionDto)
        {
            Transaction transaction = await _context.Transactions.FindAsync(id);

            if (transaction is null)

                throw new NotFoundException("Transaction does not exist!");

            bool isChanged = false;

            //Only update for a newer file. 
            if (transaction.Attachment == null && updateTransactionDto.File != null)
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

                transaction.Attachment = fileContent;
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

            if (transaction.State != updateTransactionDto.State)
            {
                transaction.State = updateTransactionDto.State;
                isChanged = true;

                if (transaction.State == (int)TransactionState.Finished
                    && !string.IsNullOrWhiteSpace(transaction.SourceAccountOrCardCode)
                    && !string.IsNullOrWhiteSpace(transaction.DestinationAccountOrCardCode))
                {

                }
            }

            if (isChanged)
            {
                transaction.UpdatedDate = DateTime.UtcNow;
                try
                {
                    _context.Entry(transaction).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return transaction;
        }

        private async Task Insert(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        private async Task InsertIgnoringRules(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

    }
}