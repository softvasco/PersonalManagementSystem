using Shared.Dtos.Transactions;
using api.Models;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionDto>> GetAsync();
        Task<Transaction> GetByIdAsync(int id);
        Task<Transaction> CreateAsync(Transaction transaction);
        Task<Transaction> UpdateAsync(int id, UpdateTransactionDto updateTransactionDto);
        Task<Transaction> DeleteAsync(int id);
        Task<Transaction> ConfirmTransactionAsync(int id);
    }
}