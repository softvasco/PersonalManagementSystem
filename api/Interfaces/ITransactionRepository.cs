using api.Dtos.Transactions;
using api.Models;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction, bool ignoreRules);
        Task<TransactionDto> GetByCodeId(int id);
        Task<Transaction> UpdateAsync(int id, Transaction transaction);
        Task<Transaction> DeleteAsync(int id);
    }
}
