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
                Description = createFinanceGoalDto.Description,
                Code = createFinanceGoalDto.Code,
                CurrentDebtAmount = createFinanceGoalDto.CurrentDebtAmount,
                OutstandingAmount = createFinanceGoalDto.OutstandingAmount,
                UserId = createFinanceGoalDto.UserId,
                Goal = createFinanceGoalDto.Goal,
                StartGoalDate = createFinanceGoalDto.StartGoalDate,
                EndGoalDate = createFinanceGoalDto.EndGoalDate
            };
        }
    }
}