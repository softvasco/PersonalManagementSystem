using api.Dtos.BankAccounts;
using api.Models;

namespace api.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> CreateAsync(BankAccount bankAccount);
        Task<BankAccount> DeleteAsync(int id);
        Task<BankAccountDto> GetByCodeAsync(string code);
        Task<BankAccount> UpdateAsync(int id, BankAccount bankAccount);
    }
}
