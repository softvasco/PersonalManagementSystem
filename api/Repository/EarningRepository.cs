using api.Data;
using api.Dtos.Earnings;
using api.Enum;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class EarningRepository : IEarningRepository
    {
        private readonly ApplicationDBContext _context;

        public EarningRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<EarningDto>> Get()
        {
            var earnings = await _context.Earnings
                .AsNoTracking()
                .Where(x => x.IsActive)
                .ToListAsync();

            if (earnings == null || !earnings.Any())
            {
                throw new NotFoundException("No earnings found for the specified user");
            }

            return earnings.Select(c => c.ToEarningDtoFromEarning()).ToList();
        }

        public async Task<EarningDto> GetByIdAsync(int id)
        {
            var earning = await _context.Earnings
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.IsActive && x.Id == id);

            if (earning == null)
            {
                throw new NotFoundException("No earning found for the specified id");
            }

            return earning.ToEarningDtoFromEarning();
        }

        public async Task<Earning> CreateAsync(Earning earning)
        {
            var userExists = await _context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == earning.UserId && x.IsActive);

            if (userExists is null)
            {
                throw new NotFoundException("User does not exist!");
            }

            var earningExists = await _context
                .Earnings
                .AsNoTracking()
                .AnyAsync(x => x.Code == earning.Code
                    && x.UserId == earning.UserId
                    && x.IsActive);

            if (earningExists)
            {
                throw new Exception("Earning already exists!");
            }

            await _context.Earnings.AddAsync(earning);
            await _context.SaveChangesAsync();

            DateTime indexData = Utils.CalculateNextPaymentDate(earning.StartDate, earning.PayDay);

            while (indexData < earning.EndDate)
            {
                if (earning.Months.Contains(indexData.Month))
                {
                    await _context.Transactions.AddAsync(new Transaction
                    {
                        OperationDate = indexData,
                        Description = earning.Description,
                        State = (int)TransactionState.Pending,
                        UserId = earning.UserId,
                        EarningId = earning.Id,
                        SourceAccountOrCardCode = null,
                        DestinationAccountOrCardCode = earning.DestinationAccountOrCardCode,
                        Amount = earning.Amount,
                        Attachment = null,
                    });
                }

                indexData = indexData.AddMonths(1);
            }

            await _context.SaveChangesAsync();

            return earning;
        }

     
        public Task<Earning> UpdateAsync(int id, Earning earning)
        {
            throw new NotImplementedException();
        }

        public Task<Earning> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}