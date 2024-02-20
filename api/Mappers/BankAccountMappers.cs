using api.Dtos.BankAccounts;
using api.Models;

namespace api.Mappers
{
    public static class BankAccountMappers
    {
        public static BankAccount ToBankAccountFromCreateBankAccountDto(this CreateBankAccountDto createBankAccountDto)
        {
            return new BankAccount
            {
                Name = createBankAccountDto.Name,
                Code = createBankAccountDto.Code,
                Description = createBankAccountDto.Description,
                Balance = createBankAccountDto.Balance,
                CloseDate = createBankAccountDto.CloseDate,
                OpenDate = createBankAccountDto.OpenDate,
                IBAN = createBankAccountDto.IBAN,
                UserId = createBankAccountDto.UserId
            };
        }
    }
}