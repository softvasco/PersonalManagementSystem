using api.Data;
using api.Dtos.Dropdown;
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
            return subCategories.Select(x => new DropdownDto { Id = x.Id, Description = x.Description }).ToList();
        }
    }
}