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

        public async Task<List<GiftCardDto>> GetAsync()
        {
            var giftCards = await _context.GiftCards
              .Where(x => x.IsActive)
              .ToListAsync();

            if (giftCards == null || !giftCards.Any())
            {
                throw new NotFoundException("No gift cards found for the specified user");
            }

            return giftCards.Select(c => c.ToGiftCardDtoFromGiftCard()).ToList();
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

        public async Task<GiftCard> UpdateAsync(int id, GiftCard giftCard)
        {
            var existingGiftCard = await _context
              .GiftCards
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingGiftCard == null)
            {
                throw new NotFoundException("Gift card not found");
            }

            existingGiftCard.UpdatedDate = DateTime.UtcNow;
            existingGiftCard.OpenDate = giftCard.OpenDate;
            existingGiftCard.CloseDate = giftCard.CloseDate;
            existingGiftCard.Description = giftCard.Description;
            if (existingGiftCard.CloseDate is not null)
                existingGiftCard.IsActive = false;
            existingGiftCard.Balance = giftCard.Balance;
            existingGiftCard.Code = giftCard.Code;

            //Only update for a newer file. 
            if (giftCard.Attachment != null)
                existingGiftCard.Attachment = giftCard.Attachment;

            try
            {
                _context.Entry(existingGiftCard).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingGiftCard;
        }

        public Task<GiftCard> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    
    }
}