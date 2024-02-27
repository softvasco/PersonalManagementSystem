using api.Data;
using api.Dtos.Credits;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly ApplicationDBContext _context;

        public CreditRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Credit> CreateAsync(Credit credit)
        {
            var userExists = await _context
                .Users
                .AsNoTracking()
                .AnyAsync(x => x.Id == credit.UserId && x.IsActive);

            if (!userExists)
            {
                throw new NotFoundException("User does not exist!");
            }

            var creditExists = await _context
                .Credits
                .AsNoTracking()
                .AnyAsync(x => x.Code == credit.Code
                    && x.UserId == credit.UserId
                    && x.IsActive);

            if (creditExists)
            {
                throw new Exception("Credit already exists!");
            }

            await _context.Credits.AddAsync(credit);
            await _context.SaveChangesAsync();

            return credit;
        }

        public async Task<CreditDto> GetByCodeAsync(string code)
        {
            var existingCredit = await _context
                .Credits
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code.ToLower() == code.ToLower() && x.IsActive);

            if (existingCredit == null)
            {
                throw new NotFoundException("Credit not found");
            }

            return existingCredit.ToCreditDtoFromCredit();
        }

        public async Task<Credit> UpdateAsync(int id, Credit credit)
        {
            throw new NotImplementedException();
        }

        public async Task<Credit> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}