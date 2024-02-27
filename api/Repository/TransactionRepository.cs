using api.Data;
using api.Dtos.Transactions;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _context;

        public TransactionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<Transaction> CreateAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDto> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> UpdateAsync(int id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}