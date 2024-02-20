using api.Dtos.FinanceGoals;
using api.Models;

namespace api.Mappers
{
    public static class FinanceGoalMappers
    {
        public static FinanceGoal ToFinanceGoalFromCreateFinanceGoalDto(this CreateFinanceGoalDto createFinanceGoalDto)
        {
            return new FinanceGoal
            {
                Name = createFinanceGoalDto.Name,
                Description = createFinanceGoalDto.Description,
                CurrentDebtAmount = createFinanceGoalDto.CurrentDebtAmount,
                OutstandingAmount = createFinanceGoalDto.OutstandingAmount,
                UserId = createFinanceGoalDto.UserId,
                Goal = createFinanceGoalDto.Goal
            };
        }
    }
}