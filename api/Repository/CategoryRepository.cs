using api.Data;
using api.Interfaces;
using api.Models;

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
            if (!_context.Users.Any(x => x.Id == category.UserId))
                throw new Exception("User does not exists!");

            if (_context.Categories.Any(x => x.Name == category.Name && x.UserId == category.UserId))
                throw new Exception("Category already exists!");

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

    }
}