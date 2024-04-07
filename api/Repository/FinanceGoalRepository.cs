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

        public async Task<FinanceGoal> CreateAsync(FinanceGoal financeGoalModel)
        {
            if (!_context
                .Users
                .AsNoTracking()
                .Any(x => x.Id == financeGoalModel.UserId && x.IsActive))
                throw new Exception("User does not exists!");

            if (_context
                .FinanceGoals
                .AsNoTracking()
                .Any(x => x.Code == financeGoalModel.Code && x.UserId == financeGoalModel.UserId && x.IsActive))
                throw new Exception("Finance Goal already exists!");

            await _context.FinanceGoals.AddAsync(financeGoalModel);
            await _context.SaveChangesAsync();
            return financeGoalModel;
        }

        public async Task<FinanceGoal> UpdateAsync(int id, FinanceGoal financeGoal)
        {
            throw new NotImplementedException();
        }

        public async Task<FinanceGoal> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}