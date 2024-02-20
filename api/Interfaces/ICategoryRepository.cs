using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}
