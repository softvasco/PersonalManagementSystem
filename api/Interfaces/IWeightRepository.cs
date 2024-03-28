using api.Dtos.Categories;
using api.Models;

namespace api.Interfaces
{
    public interface IWeightRepository
    {
        Task<List<WeigthDto>> GetAsync();
        Task<Weigth> CreateAsync(Weigth weigth);
        Task<Weigth> UpdateAsync(int id, Weigth weigth);
        Task<Weigth> DeleteAsync(int id);
    }
}
