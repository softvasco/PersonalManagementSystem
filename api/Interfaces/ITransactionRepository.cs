using api.Dtos.Transactions;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction, bool ignoreRules);
        Task<Transaction> UpdateAsync(int id, UpdateTransactionDto updateTransactionDto);
        Task<Transaction> DeleteAsync(int id);
        Task<Transaction> ConfirmTransactionAsync(int id);
        Task<Transaction> GetByIdAsync(int id);
    }
}
