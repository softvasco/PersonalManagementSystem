using api.Data;
using api.Dtos.BankAccounts;
using api.Dtos.CreditCards;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationDBContext _context;

        public CreditCardRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CreditCardDto> GetByCodeAsync(string code)
        {
            var existingCreditCard = await _context
                .CreditCards
                .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower() && x.IsActive);

            if (existingCreditCard == null)
            {
                throw new NotFoundException("Credit card not found");
            }

            return existingCreditCard.ToCreditCardDtoFromCreditCard();
        }

        public async Task<CreditCard> CreateAsync(CreditCard creditCard)
        {
            var userExists = await _context
                .Users
                .AnyAsync(x => x.Id == creditCard.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var creditCardExists = await _context
                .CreditCards
                .AnyAsync(x => x.Code == creditCard.Code
                    && x.UserId == creditCard.UserId
                    && x.IsActive);

            if (creditCardExists)
            {
                throw new Exception("Bank account already exists!");
            }

            await _context.CreditCards.AddAsync(creditCard);
            await _context.SaveChangesAsync();

            return creditCard;
        }

        public async Task<CreditCard> DeleteAsync(int id)
        {
            var creditCard = await _context
                .CreditCards
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (creditCard is null)
            {
                return null!;
            }

            creditCard.IsActive = false;
            _context.Entry(creditCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return creditCard;
        }

        public async Task<CreditCard> UpdateAsync(int id, CreditCard creditCard)
        {
            var existingCreditCard = await _context
                .CreditCards
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingCreditCard == null)
            {
                throw new NotFoundException("Bank account not found");
            }

            existingCreditCard.UpdatedDate = DateTime.UtcNow;
            existingCreditCard.OpenDate = creditCard.OpenDate;
            existingCreditCard.CloseDate = creditCard.CloseDate;
            existingCreditCard.Description = creditCard.Description;
            if (existingCreditCard.CloseDate is not null)
                existingCreditCard.IsActive = false;
            existingCreditCard.Balance = creditCard.Balance;
            existingCreditCard.IBAN = creditCard.IBAN;
            existingCreditCard.NIB = creditCard.NIB;
            existingCreditCard.Code = creditCard.Code;
            existingCreditCard.Name = creditCard.Name;

            try
            {
                _context.Entry(existingCreditCard).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingCreditCard;
        }

    }
}