using api.Data;
using api.Dtos.Categories;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            if (!_context
                .Users
                .AsNoTracking()
                .Any(x => x.Id == category.UserId && x.IsActive))
                throw new Exception("User does not exists!");

            if (_context
                .Categories
                .AsNoTracking()
                .Any(x => x.Code == category.Code && x.UserId == category.UserId && x.IsActive))
                throw new Exception("Category already exists!");

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryDto> GetByCodeAsync(string code)
        {
            var existingCategory = await _context
               .Categories
               .AsNoTracking()
               .Include(x => x.SubCategories)
               .FirstOrDefaultAsync(x =>
                    (x.Code.ToLower() == code.ToLower() && x.IsActive)
                    ||
                    x.SubCategories.Any(y => y.Code.ToLower() == code.ToLower() && y.IsActive));

            if (existingCategory == null)
            {
                throw new NotFoundException("Category not found");
            }

            return existingCategory.ToCategoryDtoFromCategory();
        }

        public async Task<List<CategoryDto>> GetByUserIdAsync(int userId)
        {
            var categories = await _context.Categories
                .Where(x => x.UserId == userId)
                .Include(x => x.SubCategories)
                .ToListAsync();

            if (categories == null || !categories.Any())
            {
                throw new NotFoundException("No categories found for the specified user");
            }

            return categories.Select(c => c.ToCategoryDtoFromCategory()).ToList();
        }

        public Task<Category> UpdateAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}