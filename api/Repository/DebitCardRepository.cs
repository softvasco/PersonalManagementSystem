using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class DebitCardRepository : IDebitCardRepository
    {
        private readonly ApplicationDBContext _context;

        public DebitCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DebitCard> CreateAsync(DebitCard debitCard)
        {
            if (!_context.Users.Any(x => x.Id == debitCard.UserId))
                throw new Exception("User does not exists!");

            if (_context.BankAccounts.Any(x => x.Code == debitCard.Code && x.UserId == debitCard.UserId))
                throw new Exception("Credit card already exists!");

            await _context.DebitCards.AddAsync(debitCard);
            await _context.SaveChangesAsync();
            return debitCard;
        }
    }
}