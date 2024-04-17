using api.Data;
using Shared.Dtos.FinanceGoals;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class FinanceGoalRepository : IFinanceGoalRepository
    {
        private readonly ApplicationDBContext _context;

        public FinanceGoalRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<FinanceGoalDto>> GetAsync()
        {
            var financeGoals = await _context.FinanceGoals
             .Where(x => x.IsActive)
             .ToListAsync();

            if (financeGoals == null || !financeGoals.Any())
            {
                throw new NotFoundException("No finance goals found for the specified user");
            }

            return financeGoals.Select(c => c.ToFinanceGoalDtoFromFinanceGoal()).ToList();
        }

        public async Task<FinanceGoal> CreateAsync(FinanceGoal financeGoal)
        {
            if (!_context
                .Users
                .AsNoTracking()
                .Any(x => x.Id == financeGoal.UserId && x.IsActive))
                throw new Exception("User does not exists!");

            if (_context
                .FinanceGoals
                .AsNoTracking()
                .Any(x => x.Code == financeGoal.Code && x.UserId == financeGoal.UserId && x.IsActive))
                throw new Exception("Finance Goal already exists!");

            await _context.FinanceGoals.AddAsync(financeGoal);
            await _context.SaveChangesAsync();
            return financeGoal;
        }

        public async Task<FinanceGoal> UpdateAsync(int id, FinanceGoal financeGoal)
        {
            if (!_context
                .Users
                .AsNoTracking()
                .Any(x => x.Id == financeGoal.UserId && x.IsActive))
                throw new Exception("User does not exists!");

            FinanceGoal? existingFinanceGoal = await _context.FinanceGoals.FindAsync(id) ?? throw new Exception("Finance Goal does not exists!");

            existingFinanceGoal.UpdatedDate = DateTime.UtcNow;
            existingFinanceGoal.IsActive = true;
            existingFinanceGoal.EndGoalDate = financeGoal.EndGoalDate;
            existingFinanceGoal.StartGoalDate = financeGoal.StartGoalDate;
            existingFinanceGoal.Code = financeGoal.Code;
            existingFinanceGoal.CreatedDate = financeGoal.CreatedDate;
            existingFinanceGoal.EndGoalDate = financeGoal.EndGoalDate;
            existingFinanceGoal.CurrentDebtAmount = financeGoal.CurrentDebtAmount;
            existingFinanceGoal.Goal = financeGoal.Goal;
            existingFinanceGoal.Description = financeGoal.Description;

            try
            {
                _context.Entry(existingFinanceGoal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingFinanceGoal;
        }

        public async Task<FinanceGoal> DeleteAsync(int id)
        {
            var existingFinanceGoal = await _context
              .FinanceGoals
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingFinanceGoal == null)
            {
                throw new NotFoundException("Finance Goal not found");
            }

            existingFinanceGoal.UpdatedDate = DateTime.Now;
            existingFinanceGoal.IsActive = false;

            try
            {
                _context.Entry(existingFinanceGoal).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingFinanceGoal;
        }

    }
}