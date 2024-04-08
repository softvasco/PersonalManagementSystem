using Shared.Dtos.FinanceGoals;
using api.Models;

namespace api.Interfaces
{
    public interface IFinanceGoalRepository
    {
        Task<List<FinanceGoalDto>> GetAsync();
        Task<FinanceGoal> CreateAsync(FinanceGoal financeGoal);
    }
}