using api.Dtos.FinanceGoals;
using api.Models;

namespace api.Interfaces
{
    public interface IFinanceGoalRepository
    {
        Task<FinanceGoal> CreateAsync(FinanceGoal financeGoal);
        Task<FinanceGoalDto> GetByCodeAsync(string code);
        Task<FinanceGoal> UpdateAsync(int id, FinanceGoal financeGoal);
        Task<FinanceGoal> DeleteAsync(int id);
    }
}
