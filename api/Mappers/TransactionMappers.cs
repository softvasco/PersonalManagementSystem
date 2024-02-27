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
              
                UserId = createTransactionDto.UserId,

                Attachment = fileContent
            };
        }
    }
}