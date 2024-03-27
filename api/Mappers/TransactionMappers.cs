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

        public static UpdateTransactionDto ToUpdateTransactionDtoFromTransaction(this Transaction transaction)
        {
            return new UpdateTransactionDto
            {
                Description = transaction.Description,
                Amount = transaction.Amount,
                UserId = transaction.UserId,
                CreditId = transaction.CreditId,
                DestinationAccountOrCardCode = transaction.DestinationAccountOrCardCode,
                SubCategoryId = transaction.SubCategoryId,
                SourceAccountOrCardCode = transaction.SourceAccountOrCardCode,
                EarningId = transaction.EarningId,
                ExpenseId = transaction.ExpenseId,
                OperationDate = transaction.OperationDate,
                //Attachment = fileContent,
                //State = createTransactionDto.State
            };
        }


    }
}