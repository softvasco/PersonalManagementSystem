using Shared.Dtos.SubCategories;
using api.Models;

namespace api.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategoryDto>> GetAsync();
        Task<SubCategory> CreateAsync(SubCategory subCategory);
        Task<SubCategory> UpdateAsync(int id, SubCategory subCategory);
        Task<SubCategory> DeleteAsync(int id);
    }
}