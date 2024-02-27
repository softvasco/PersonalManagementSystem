using api.Data;
using api.Dtos.Categories;
using api.Interfaces;
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

        public Task<CategoryDto> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
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