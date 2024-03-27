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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="giftCard"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<GiftCard> CreateAsync(GiftCard giftCard)
        {
            var userExists = await _context
               .Users
               .AnyAsync(x => x.Id == giftCard.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var giftCardExists = await _context
                .GiftCards
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="giftCard"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<GiftCard> UpdateAsync(int id, GiftCard giftCard)
        {
            var existingGiftCard = await _context
              .GiftCards
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingGiftCard == null)
            {
                throw new NotFoundException("Gift card not found");
            }

            existingGiftCard.UpdatedDate = DateTime.UtcNow;
            existingGiftCard.OpenDate = giftCard.OpenDate;
            existingGiftCard.CloseDate = giftCard.CloseDate;
            existingGiftCard.Description = giftCard.Description;
            existingGiftCard.Balance = giftCard.Balance;

            string code = existingGiftCard.Code;
            if (existingGiftCard.Code != giftCard.Code)
            {
                existingGiftCard.Code = giftCard.Code;
            }

            //Only update for a newer file. 
            if (giftCard.Attachment != null)
            {
                existingGiftCard.Attachment = giftCard.Attachment;
                existingGiftCard.FileName = giftCard.FileName;
            }

            try
            {
                _context.Entry(existingGiftCard).State = EntityState.Modified;

                var dest = _context.Transactions.Where(x => x.DestinationAccountOrCardCode == code);
                foreach (var transactionDesc in dest)
                {
                    transactionDesc.DestinationAccountOrCardCode = giftCard.Code;
                    transactionDesc.UpdatedDate = DateTime.Now;
                    _context.Entry(transactionDesc).State = EntityState.Modified;
                }
                var source = _context.Transactions.Where(x => x.SourceAccountOrCardCode == code);
                foreach (var transactionSource in source)
                {
                    transactionSource.SourceAccountOrCardCode = giftCard.Code;
                    transactionSource.UpdatedDate = DateTime.Now;
                    _context.Entry(transactionSource).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingGiftCard;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<GiftCard> DeleteAsync(int id)
        {
            var existingGiftCard = await _context
             .GiftCards
             .AsNoTracking()
             .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingGiftCard == null)
            {
                throw new NotFoundException("Gift card not found");
            }

            existingGiftCard.UpdatedDate = DateTime.Now;
            existingGiftCard.IsActive = false;

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

    }
}