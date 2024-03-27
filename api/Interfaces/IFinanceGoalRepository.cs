using api.Dtos.FinanceGoals;
using api.Models;

namespace api.Interfaces
{
    public interface IFinanceGoalRepository
    {
        Task<List<FinanceGoalDto>> GetAsync();
        Task<FinanceGoal> CreateAsync(FinanceGoal financeGoal);
        Task<FinanceGoal> UpdateAsync(int id, FinanceGoal financeGoal);
        Task<FinanceGoal> DeleteAsync(int id);
    }
}
