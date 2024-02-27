using api.Dtos.Expenses;
using api.Models;

namespace api.Mappers
{
    public static class ExpenseMappers
    {
        public static async Task<Expense> ToExpenseFromCreateExpenseDtoAsync(this CreateExpenseDto createExpenseDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (createExpenseDto.File is not null)
                {
                    await createExpenseDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new Expense
            {
               Code = createExpenseDto.Code,
               Amount = createExpenseDto.Amount,
               Description = createExpenseDto.Description,
               DestinationAccountOrCardCode = createExpenseDto.DestinationAccountOrCardCode,
               FileContent = fileContent,
               SubCategoryId = createExpenseDto.SubCategoryId,
               PayDay = createExpenseDto.PayDay,
               Months = createExpenseDto.Months,
               SourceAccountOrCardCode = createExpenseDto.SourceAccountOrCardCode,
               StartDate = createExpenseDto.StartDate,
               EndDate = createExpenseDto.EndDate
            };
        }

        public static async Task<Expense> ToBankAccountFromUpdateBankAccountDto(this UpdateExpenseDto updateExpenseDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (updateExpenseDto.File is not null)
                {
                    await updateExpenseDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new Expense
            {
                Code = updateExpenseDto.Code,
                Amount = updateExpenseDto.Amount,
                Description = updateExpenseDto.Description,
                DestinationAccountOrCardCode = updateExpenseDto.DestinationAccountOrCardCode,
                FileContent = fileContent,
                SubCategoryId = updateExpenseDto.SubCategoryId,
                PayDay = updateExpenseDto.PayDay,
                Months = updateExpenseDto.Months,
                SourceAccountOrCardCode = updateExpenseDto.SourceAccountOrCardCode,
                StartDate = updateExpenseDto.StartDate,
                EndDate = updateExpenseDto.EndDate
            };
        }
    
    }
}