using api.Dtos.Expenses;
using api.Models;

namespace api.Mappers
{
    public static class ExpenseMappers
    {
        public static Expense ToExpenseFromCreateExpenseDtoAsync(this CreateExpenseDto createExpenseDto)
        {
            return new Expense
            {
               Code = createExpenseDto.Code,
               Amount = createExpenseDto.Amount,
               Description = createExpenseDto.Description,
               DestinationAccountOrCardCode = createExpenseDto.DestinationAccountOrCardCode,
               UserId = createExpenseDto.UserId,
               PayDay = createExpenseDto.PayDay,
               Months = createExpenseDto.Months,
               SourceAccountOrCardCode = createExpenseDto.SourceAccountOrCardCode,
               StartDate = createExpenseDto.StartDate,
               EndDate = createExpenseDto.EndDate
            };
        }

        public static Expense ToBankAccountFromUpdateBankAccountDto(this UpdateExpenseDto updateExpenseDto)
        {
            return new Expense
            {
                Code = updateExpenseDto.Code,
                Amount = updateExpenseDto.Amount,
                Description = updateExpenseDto.Description,
                DestinationAccountOrCardCode = updateExpenseDto.DestinationAccountOrCardCode,
                UserId = updateExpenseDto.UserId,
                PayDay = updateExpenseDto.PayDay,
                Months = updateExpenseDto.Months,
                SourceAccountOrCardCode = updateExpenseDto.SourceAccountOrCardCode,
                StartDate = updateExpenseDto.StartDate,
                EndDate = updateExpenseDto.EndDate
            };
        }
    
    }
}