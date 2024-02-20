using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDBContext _context;

        public CreditCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CreditCard> CreateAsync(CreditCard creditCardModel)
        {
            if (!_context.Users.Any(x => x.Id == creditCardModel.UserId))
                throw new Exception("User does not exists!");

            if (_context.BankAccounts.Any(x => x.Code == creditCardModel.Code && x.UserId == creditCardModel.UserId))
                throw new Exception("Credit card already exists!");

            await _context.CreditCards.AddAsync(creditCardModel);
            await _context.SaveChangesAsync();
            return creditCardModel;
        }
    }
}