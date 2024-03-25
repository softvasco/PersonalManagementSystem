using api.Dtos.BankAccounts;
using api.Dtos.Transactions;
using api.Enum;
using api.Helpers;
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

        public static TransactionDto ToTransactionDtoFromTransaction(this Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                State  = transaction.State,
                StateDesc = transaction.State == (int)TransactionState.Pending ? "Pending" : "Finished"
                //Code = bankAccount.Code,
                //Description = bankAccount.Description,
                //Balance = bankAccount.Balance,
                //OpenDate = bankAccount.OpenDate,
                //IBAN = bankAccount.IBAN,
                //UserId = bankAccount.UserId,
                //NIB = bankAccount.NIB,
                //Swift = bankAccount.Swift,
                //Number = bankAccount.Number,
                //FileBytes = bankAccount.Attachment,
                //FileName = bankAccount.FileName,
                //ContentType = bankAccount.Attachment != null ? ByteArrayToFormFileExtensions.GetContentTypeFromExtension(ByteArrayToFormFileExtensions.InferFileExtension(bankAccount.Attachment)) : string.Empty
            };
        }
    }
}