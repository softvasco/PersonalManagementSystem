using api.Models;

namespace api.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> CreateAsync(BankAccount bankAccountModel);
    }
}
