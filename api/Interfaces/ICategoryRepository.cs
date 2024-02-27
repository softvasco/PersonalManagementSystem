using api.Dtos.Categories;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<CategoryDto> GetByCodeAsync(string code);
        Task<Category> UpdateAsync(int id, Category category);
        Task<Category> DeleteAsync(int id);
    }
}
