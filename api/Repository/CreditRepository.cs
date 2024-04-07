using api.Data;
using Shared.Dtos.Credits;
using Shared.Enum;
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

        public async Task<List<CreditDto>> Get()
        {
            var credits = await _context.Credits
            .Where(x => x.IsActive)
            .ToListAsync();

            if (credits == null || !credits.Any())
            {
                throw new NotFoundException("No credits found for the specified user");
            }

            return credits.Select(c => c.ToCreditDtoFromCredit()).ToList();
        }

        public async Task<Credit> CreateAsync(Credit credit)
        {
            var user = await _context
                .Users
                .AnyAsync(x => x.Id == credit.UserId && x.IsActive);

            if (!user)
            {
                throw new NotFoundException("User does not exist!");
            }

            var creditExists = await _context
                .Credits
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