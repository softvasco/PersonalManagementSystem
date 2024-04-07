using api.Data;
using Shared.Dtos.Dropdown;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly ApplicationDBContext _context;

        public DropdownRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<DropdownDto>> GetSubCategories()
        {
            var subCategories = await _context.SubCategories.Where(x => x.IsActive).ToListAsync();
            return subCategories.Select(x => new DropdownDto { Id = x.Id, Description = x.Description }).OrderBy(x=>x.Description).ToList();
        }

        public async Task<List<DropdownDto>> GetSourceAccountOrCardCode()
        {
            var credits = await _context.Credits.Where(x => x.IsActive).ToListAsync();
            var creditCards = await _context.CreditCards.Where(x => x.IsActive).ToListAsync();
            var bankAccounts = await _context.BankAccounts.Where(x => x.IsActive).ToListAsync();
            var debitCards = await _context.DebitCards.Where(x => x.IsActive).ToListAsync();
            var giftCards = await _context.GiftCards.Where(x => x.IsActive).ToListAsync();

            List<DropdownDto> result =
            [
                .. credits.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. creditCards.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. bankAccounts.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. debitCards.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. giftCards.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
            ];

            return result;
        }

        public async Task<List<DropdownDto>> GetDestinationAccountOrCardCode()
        {
            var credits = await _context.Credits.Where(x => x.IsActive).ToListAsync();
            var creditCards = await _context.CreditCards.Where(x => x.IsActive).ToListAsync();
            var bankAccounts = await _context.BankAccounts.Where(x => x.IsActive).ToListAsync();
            var debitCards = await _context.DebitCards.Where(x => x.IsActive).ToListAsync();
            var giftCards = await _context.GiftCards.Where(x => x.IsActive).ToListAsync();

            List<DropdownDto> result =
            [
                .. credits.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. creditCards.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. bankAccounts.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. debitCards.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
                .. giftCards.Select(x => new DropdownDto { Code = x.Code, Description = x.Description }).OrderBy(x => x.Description).ToList(),
            ];

            return result;
        }

        public async Task<List<DropdownDto>> GetEarnings()
        {
            var earnings = await _context.Earnings.Where(x => x.IsActive).ToListAsync();
            return earnings.Select(x => new DropdownDto { Id = x.Id, Description = x.Description }).OrderBy(x => x.Description).ToList();
        }

        public async Task<List<DropdownDto>> GetExpenses()
        {
            var expenses = await _context.Expenses.Where(x => x.IsActive).ToListAsync();
            return expenses.Select(x => new DropdownDto { Id = x.Id, Description = x.Description }).OrderBy(x => x.Description).ToList();
        }


        public async Task<List<DropdownDto>> GetCredits()
        {
            var credits = await _context.Credits.Where(x => x.IsActive).ToListAsync();
            return credits.Select(x => new DropdownDto { Id = x.Id, Description = x.Description }).OrderBy(x => x.Description).ToList();
        }

    }
}