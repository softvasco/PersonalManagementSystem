using api.Data;
using api.Dtos.FinanceGoals;
using api.Interfaces;
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

        public async Task<FinanceGoalDto> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
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