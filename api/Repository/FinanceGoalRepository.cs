using api.Data;
using api.Interfaces;
using api.Models;

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
            if (!_context.Users.Any(x => x.Id == financeGoalModel.UserId))
                throw new Exception("User does not exists!");

            if (_context.FinanceGoals.Any(x => x.Code == financeGoalModel.Code && x.UserId == financeGoalModel.UserId && x.EndGoalDate == null))
                throw new Exception("Finance Goal already exists!");

            await _context.FinanceGoals.AddAsync(financeGoalModel);
            await _context.SaveChangesAsync();
            return financeGoalModel;
        }
    }
}