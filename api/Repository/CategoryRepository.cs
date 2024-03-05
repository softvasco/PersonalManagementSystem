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

        public async Task<Category> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _context
               .Categories
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingCategory == null)
            {
                throw new NotFoundException("Category not found");
            }

            existingCategory.UpdatedDate = DateTime.UtcNow;
            existingCategory.Description = category.Description;
            existingCategory.Code = category.Code;

            try
            {
                _context.Entry(existingCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingCategory;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var existingCategory = await _context
              .Categories
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if (existingCategory == null)
            {
                throw new NotFoundException("Category not found");
            }

            existingCategory.UpdatedDate = DateTime.Now;
            existingCategory.IsActive = false;

            try
            {
                _context.Entry(existingCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return existingCategory;
        }

        public async Task<List<CategoryDto>> Get()
        {
            var categories = await _context.Categories
                .Where(x => x.IsActive)
               .Include(x => x.SubCategories)
               .ToListAsync();

            if (categories == null || !categories.Any())
            {
                throw new NotFoundException("No categories found for the specified user");
            }

            return categories.Select(c => c.ToCategoryDtoFromCategory()).ToList();
        }
    }
}