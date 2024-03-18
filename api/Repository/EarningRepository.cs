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


        public async Task<Earning> UpdateAsync(int id, Earning earning)
        {
            var existingEarning = await _context
               .Earnings
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingEarning == null)
            {
                throw new NotFoundException("Earning not found");
            }

            existingEarning.UpdatedDate = DateTime.UtcNow;
            existingEarning.Description = earning.Description;
            existingEarning.Code = earning.Code;
            existingEarning.EndDate = earning.EndDate;
            existingEarning.StartDate = earning.StartDate;
            existingEarning.Amount = earning.Amount;
            existingEarning.DestinationAccountOrCardCode = earning.DestinationAccountOrCardCode;
            existingEarning.Months = earning.Months;
            existingEarning.UserId = earning.UserId;
            existingEarning.PayDay = earning.PayDay;

            try
            {
                _context.Entry(existingEarning).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _context.Transactions.RemoveRange(_context.Transactions.Where(x=>x.EarningId== existingEarning.Id && x.State==(int)TransactionState.Pending));
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
                            EarningId = existingEarning.Id,
                            SourceAccountOrCardCode = null,
                            DestinationAccountOrCardCode = earning.DestinationAccountOrCardCode,
                            Amount = earning.Amount,
                            Attachment = null,
                        });
                    }

                    indexData = indexData.AddMonths(1);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingEarning;
        }

        public async Task<Earning> DeleteAsync(int id)
        {
            var existingEarning = await _context
              .Earnings
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingEarning == null)
            {
                throw new NotFoundException("Earning not found");
            }

            existingEarning.UpdatedDate = DateTime.Now;
            existingEarning.IsActive = false;

            try
            {
                _context.Entry(existingEarning).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                _context.Transactions.RemoveRange(_context.Transactions.Where(x => x.EarningId == id && x.State == (int)TransactionState.Pending));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingEarning;
        }

    }
}