using Shared.Dtos.FinanceGoals;
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

        public static FinanceGoal ToFinanceGoalFromUpdateFinanceGoalDto(this UpdateFinanceGoalDto updateFinanceGoalDto)
        {
            return new FinanceGoal
            {
                Description = updateFinanceGoalDto.Description,
                Code = updateFinanceGoalDto.Code,
                CurrentDebtAmount = updateFinanceGoalDto.CurrentDebtAmount,
                OutstandingAmount = updateFinanceGoalDto.OutstandingAmount,
                UserId = updateFinanceGoalDto.UserId,
                Goal = updateFinanceGoalDto.Goal,
                StartGoalDate = updateFinanceGoalDto.StartGoalDate,
                EndGoalDate = updateFinanceGoalDto.EndGoalDate
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