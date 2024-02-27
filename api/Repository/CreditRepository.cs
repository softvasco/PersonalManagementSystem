using api.Data;
using api.Dtos.Credits;
using api.Enum;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly ApplicationDBContext _context;

        public CreditRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Credit> CreateAsync(Credit credit)
        {
            var userExists = await _context
                .Users
                .AsNoTracking()
                .AnyAsync(x => x.Id == credit.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var creditExists = await _context
                .Credits
                .AsNoTracking()
                .AnyAsync(x => x.Code == credit.Code
                    && x.UserId == credit.UserId
                    && x.IsActive);

            if (creditExists)
            {
                throw new Exception("Credit already exists!");
            }

            await _context.Credits.AddAsync(credit);
            await _context.SaveChangesAsync();

            if (credit.TAN == 0)
            {
                await InsertTransactionWith0Tan(credit);
            }
            else
            {
                await InsertTransactions(credit);
            }

            return credit;
        }

        public async Task<CreditDto> GetByCodeAsync(string code)
        {
            var existingCredit = await _context
                .Credits
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower() && x.IsActive);

            if (existingCredit == null)
            {
                throw new NotFoundException("Credit not found");
            }

            return existingCredit.ToCreditDtoFromCredit();
        }

        public async Task<Credit> UpdateAsync(int id, Credit credit)
        {
            throw new NotImplementedException();
        }

        public async Task<Credit> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        private async Task InsertTransactions(Credit credit)
        {
            DateTime indexData = Utils.CalculateNextPaymentDate(credit.OpenDate, credit.PayDay);

            while (indexData <= credit.CloseDate)
            {
                await _context.Transactions.AddAsync(new Transaction
                {
                    OperationDate = indexData,
                    Description = credit.Description,
                    State = (int)TransactionState.Pending,
                    UserId = credit.UserId,
                    SourceAccountOrCardCode = credit.AccountOrCardCodeToDebt,
                    Amount = credit.Installment,
                    Attachment = null,
                    CreditId = credit.Id,
                    DestinationAccountOrCardCode = credit.Code,
                });

                indexData = indexData.AddMonths(1);
            }

            await _context.SaveChangesAsync();
        }

        private async Task InsertTransactionWith0Tan(Credit credit)
        {
            DateTime indexData = Utils.CalculateNextPaymentDate(credit.OpenDate, credit.PayDay);
            int numbOfTrans = 0;

            while (indexData <= credit.CloseDate)
            {
                numbOfTrans++;
                indexData = indexData.AddMonths(1);
            }

            indexData = Utils.CalculateNextPaymentDate(credit.OpenDate, credit.PayDay);
            while (indexData <= credit.CloseDate)
            {
                await _context.Transactions.AddAsync(new Transaction
                {
                    OperationDate = indexData,
                    Description = credit.Description,
                    State = (int)TransactionState.Pending,
                    UserId = credit.UserId,
                    SourceAccountOrCardCode = credit.AccountOrCardCodeToDebt,
                    Amount = credit.DebtCapital / numbOfTrans,
                    Attachment = null,
                    CreditId = credit.Id,
                    DestinationAccountOrCardCode = credit.Code
                });

                indexData = indexData.AddMonths(1);
            }

            await _context.SaveChangesAsync();
        }
    }
}