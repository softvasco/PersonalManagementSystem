using api.Dtos.Categories;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> Get();
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(int id, Category category);
        Task<Category> DeleteAsync(int id);
    }
}
