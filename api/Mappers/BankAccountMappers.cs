using api.Dtos.BankAccounts;
using api.Helpers;
using api.Models;

namespace api.Mappers
{
    public static class BankAccountMappers
    {
        public static async Task<BankAccount> ToBankAccountFromCreateBankAccountDtoAsync(this CreateBankAccountDto createBankAccountDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (createBankAccountDto.File is not null)
                {
                    await createBankAccountDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new BankAccount
            {
                Code = createBankAccountDto.Code,
                Description = createBankAccountDto.Description,
                Balance = createBankAccountDto.Balance,
                OpenDate = createBankAccountDto.OpenDate,
                IBAN = createBankAccountDto.IBAN,
                UserId = createBankAccountDto.UserId,
                NIB = createBankAccountDto.NIB,
                Swift = createBankAccountDto.Swift,
                Number = createBankAccountDto.Number,
                Attachment = fileContent,
                FileName = createBankAccountDto.FileName,
            };
        }

        public static async Task<BankAccount> ToBankAccountFromUpdateBankAccountDto(this UpdateBankAccountDto updateBankAccountDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (updateBankAccountDto.File is not null)
                {
                    await updateBankAccountDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new BankAccount
            {
                Code = updateBankAccountDto.Code,
                Description = updateBankAccountDto.Description,
                Balance = updateBankAccountDto.Balance,
                OpenDate = updateBankAccountDto.OpenDate,
                IBAN = updateBankAccountDto.IBAN,
                UserId = updateBankAccountDto.UserId,
                NIB = updateBankAccountDto.NIB,
                Swift = updateBankAccountDto.Swift,
                Number = updateBankAccountDto.Number,
                Attachment = fileContent,
                FileName = updateBankAccountDto.FileName,
            };
        }
    
        public static BankAccountDto ToBankAccountDtoFromBankAccount(this BankAccount bankAccount)
        {
            return new BankAccountDto
            {
                Id = bankAccount.Id,
                Code = bankAccount.Code,
                Description = bankAccount.Description,
                Balance = bankAccount.Balance,
                OpenDate = bankAccount.OpenDate,
                IBAN = bankAccount.IBAN,
                UserId = bankAccount.UserId,
                NIB = bankAccount.NIB,
                Swift = bankAccount.Swift,
                Number = bankAccount.Number,
                FileBytes = bankAccount.Attachment,
                FileName = bankAccount.FileName,
                ContentType = bankAccount.Attachment != null ? ByteArrayToFormFileExtensions.GetContentTypeFromExtension(ByteArrayToFormFileExtensions.InferFileExtension(bankAccount.Attachment)) : string.Empty
            };
        }
    }
}