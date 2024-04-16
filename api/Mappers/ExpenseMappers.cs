using Shared.Dtos.Expenses;
using api.Models;

namespace api.Mappers
{
    public static class ExpenseMappers
    {
        public static ExpenseDto ToExpenseDtoFromExpense(this Expense expense)
        {
            return new ExpenseDto
            {
                Id = expense.Id,
                Code = expense.Code,
                Amount = expense.Amount,
                Description = expense.Description,
                DestinationAccountOrCardCode = expense.DestinationAccountOrCardCode,
                UserId = expense.UserId,
                PayDay = expense.PayDay,
                Months = string.Join(", ", expense.Months),
                SourceAccountOrCardCode = expense.SourceAccountOrCardCode,
                StartDate = expense.StartDate,
                EndDate = expense.EndDate,
                SubCategoryName = "",
                SubCategoryId = expense.SubCategoryId

            };
        }

        public static Expense ToExpenseFromCreateExpenseDto(this CreateExpenseDto createExpenseDto)
        {
            return new Expense
            {
                Code = createExpenseDto.Code,
                Amount = createExpenseDto.Amount,
                Description = createExpenseDto.Description,
                DestinationAccountOrCardCode = createExpenseDto.DestinationAccountOrCardCode,
                UserId = createExpenseDto.UserId,
                PayDay = createExpenseDto.PayDay,
                Months = createExpenseDto.Months.ToString()!.Split(',').Select(int.Parse).ToList(),
                SourceAccountOrCardCode = createExpenseDto.SourceAccountOrCardCode,
                StartDate = createExpenseDto.StartDate,
                EndDate = createExpenseDto.EndDate,
                SubCategoryId = createExpenseDto.SubCategoryId
            };
        }

        public static Expense ToExpenseFromUpdateExpenseDto(this UpdateExpenseDto updateExpenseDto)
        {
            return new Expense
            {
                Code = updateExpenseDto.Code,
                Amount = updateExpenseDto.Amount,
                Description = updateExpenseDto.Description,
                DestinationAccountOrCardCode = updateExpenseDto.DestinationAccountOrCardCode,
                UserId = updateExpenseDto.UserId,
                PayDay = updateExpenseDto.PayDay,
                Months = updateExpenseDto.Months.Split(',').Select(int.Parse).ToList(),
                SourceAccountOrCardCode = updateExpenseDto.SourceAccountOrCardCode,
                EndDate = updateExpenseDto.EndDate,
                SubCategoryId = updateExpenseDto.SubCategoryId
            };
        }
    
    }
}