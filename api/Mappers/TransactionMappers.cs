using api.Dtos.Transactions;
using api.Models;

namespace api.Mappers
{
    public static class TransactionMappers
    {
        public static async Task<Transaction> ToTransactionFromCreateTransactionDto(this CreateTransactionDto createTransactionDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (createTransactionDto.File is not null)
                {
                    await createTransactionDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new Transaction
            {
                Description = createTransactionDto.Description,
                Amount = createTransactionDto.Amount,
                UserId = createTransactionDto.UserId,
                CreditId = createTransactionDto.CreditId,
                DestinationAccountOrCardCode = createTransactionDto.DestinationAccountOrCardCode,
                SubCategoryId = createTransactionDto.SubCategoryId,
                SourceAccountOrCardCode = createTransactionDto.SourceAccountOrCardCode,
                EarningId = createTransactionDto.EarningId,
                ExpenseId = createTransactionDto.ExpenseId,
                OperationDate = createTransactionDto.OperationDate,
                Attachment = fileContent,
                State = createTransactionDto.State
            };
        }


    }
}