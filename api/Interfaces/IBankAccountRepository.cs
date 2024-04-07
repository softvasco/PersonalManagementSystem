using Shared.Dtos.BankAccounts;
using api.Models;

namespace api.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<List<BankAccountDto>> GetAsync();
        Task<BankAccount> CreateAsync(BankAccount bankAccount);
        Task<BankAccount> UpdateAsync(int id, BankAccount bankAccount);
        Task<BankAccount> DeleteAsync(int id);
    }
}