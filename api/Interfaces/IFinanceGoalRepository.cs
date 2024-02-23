using api.Models;

namespace api.Interfaces
{
    public interface IFinanceGoalRepository
    {
        Task<FinanceGoal> CreateAsync(FinanceGoal financeGoal);
    }
}
