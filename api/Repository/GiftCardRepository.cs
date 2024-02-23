using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class GiftCardRepository : IGiftCardRepository
    {
        private readonly ApplicationDBContext _context;

        public GiftCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<GiftCard> CreateAsync(GiftCard giftCard)
        {
            throw new NotImplementedException();
        }
    }
}