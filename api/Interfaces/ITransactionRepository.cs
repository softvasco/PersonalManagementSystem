using api.Models;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<Transaction> UpdateAsync(int id, Transaction transaction);
        Task<Transaction> DeleteAsync(int id);
    }
}
