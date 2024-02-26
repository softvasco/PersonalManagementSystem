﻿using api.Data;
using api.Dtos.DebitCards;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

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
            var userExists = await _context
                        .Users
                        .AnyAsync(x => x.Id == debitCard.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var debitCardExists = await _context
               .DebitCards
               .AnyAsync(x => x.Code == debitCard.Code
                   && x.UserId == debitCard.UserId
                   && x.IsActive);

            if (debitCardExists)
            {
                throw new Exception("Debit card already exists!");
            }

            await _context.DebitCards.AddAsync(debitCard);
            await _context.SaveChangesAsync();

            return debitCard;
        }

        public async Task<DebitCard> DeleteAsync(int id)
        {
            var debitCard = await _context
               .DebitCards
               .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (debitCard is null)
            {
                return null!;
            }

            debitCard.IsActive = false;
            _context.Entry(debitCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return debitCard;
        }

        public async Task<DebitCardDto> GetByCodeAsync(string code)
        {
            var existingDebitCard = await _context
               .DebitCards
               .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower() && x.IsActive);

            if (existingDebitCard == null)
            {
                throw new NotFoundException("Bank account not found");
            }

            return existingDebitCard.ToDebitCardDtoFromDebitCard();
        }

        public async Task<DebitCard> UpdateAsync(int id, DebitCard debitCard)
        {
            var existingDebitCard = await _context
               .DebitCards
               .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingDebitCard == null)
            {
                throw new NotFoundException("Debit Card not found");
            }

            existingDebitCard.UpdatedDate = DateTime.UtcNow;
            existingDebitCard.OpenDate = debitCard.OpenDate;
            existingDebitCard.CloseDate = debitCard.CloseDate;
            existingDebitCard.Description = debitCard.Description;
            if (existingDebitCard.CloseDate is not null)
                existingDebitCard.IsActive = false;
            existingDebitCard.Balance = debitCard.Balance;
            existingDebitCard.Code = debitCard.Code;
            existingDebitCard.Name = debitCard.Name;

            try
            {
                _context.Entry(existingDebitCard).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingDebitCard;
        }
    }
}