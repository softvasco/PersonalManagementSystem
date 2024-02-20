using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public BankAccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> CreateAsync(BankAccount bankAccountModel)
        {

            if (!_context.Users.Any(x => x.Id == bankAccountModel.UserId))
                throw new Exception("User does not exists!");

            if (_context.BankAccounts.Any(x => x.Code == bankAccountModel.Code && x.UserId == bankAccountModel.UserId))
                throw new Exception("Bank account already exists!");

            await _context.BankAccounts.AddAsync(bankAccountModel);
            await _context.SaveChangesAsync();
            return bankAccountModel;
        }

    }
}