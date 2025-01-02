using api.Data;
using Shared.Enum;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SimulatorRepository : ISimulatorRepository
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ApplicationDBContext _context;

        public SimulatorRepository(
            ITransactionRepository transactionRepository,
            ApplicationDBContext context)
        {
            _context = context;
            _transactionRepository = transactionRepository;
        }

        public async Task<decimal> SimulateAsync(DateTime untilDate)
        {
            using var trans = await _context.Database.BeginTransactionAsync();

            var transactionsToSimulate = _context
                .Transactions
                .Where(x => x.OperationDate <= untilDate && x.State == (int)TransactionState.Pending)
                .AsNoTracking();

            foreach (var transaction in transactionsToSimulate)
            {
                await _transactionRepository.ConfirmTransactionAsync(transaction.Id);
            }

            decimal currentDebtAmount = _context.FinanceGoals.FirstOrDefault(x=>x.Code== "2025DecreaseDebt")!.CurrentDebtAmount;

            await trans.RollbackAsync();

            return currentDebtAmount;
        }
    }
}