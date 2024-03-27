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

        public static FinanceGoalDto ToFinanceGoalDtoFromFinanceGoal(this FinanceGoal financeGoal)
        {
            return new FinanceGoalDto
            {
                Description = financeGoal.Description,
                Code = financeGoal.Code,
                CurrentDebtAmount = financeGoal.CurrentDebtAmount,
                OutstandingAmount = financeGoal.OutstandingAmount,
                UserId = financeGoal.UserId,
                Goal = financeGoal.Goal,
                StartGoalDate = financeGoal.StartGoalDate,
                EndGoalDate = financeGoal.EndGoalDate
            };
        }

    }
}