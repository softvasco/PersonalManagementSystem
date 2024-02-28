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

        public async Task<Transaction> CreateAsync(Transaction transaction, bool ignoreRules)
        {
            try
            {
                if (ignoreRules)
                    await InsertIgnoringRules(transaction);
                else
                    await Insert(transaction);

                return transaction;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<Transaction> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionDto> GetByCodeId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaction> UpdateAsync(int id, Transaction transaction)
        {
            throw new NotImplementedException();
        }

        private async Task Insert(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        private async Task InsertIgnoringRules(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}