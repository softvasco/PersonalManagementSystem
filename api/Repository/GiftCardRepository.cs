using api.Data;
using api.Dtos.GiftCards;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GiftCardRepository : IGiftCardRepository
    {
        private readonly ApplicationDBContext _context;

        public GiftCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GiftCard> CreateAsync(GiftCard giftCard)
        {
            var userExists = await _context
               .Users
               .AsNoTracking()
               .AnyAsync(x => x.Id == giftCard.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var giftCardExists = await _context
                .GiftCards
                .AsNoTracking()
                .AnyAsync(x => x.Code == giftCard.Code
                    && x.UserId == giftCard.UserId
                    && x.IsActive);

            if (giftCardExists)
            {
                throw new Exception("Gift Card already exists!");
            }

            await _context.GiftCards.AddAsync(giftCard);
            await _context.SaveChangesAsync();

            return giftCard;
        }

        public async Task<GiftCardDto> GetByCodeAsync(string code)
        {
            var existingGiftCard = await _context
               .GiftCards
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower() && x.IsActive);

            if (existingGiftCard == null)
            {
                throw new NotFoundException("Gift Card not found");
            }

            return existingGiftCard.ToGiftCardDtoFromGiftCard();
        }

        public Task<GiftCard> UpdateAsync(int id, GiftCard giftCard)
        {
            throw new NotImplementedException();
        }

        public Task<GiftCard> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}