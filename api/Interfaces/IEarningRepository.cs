using api.Dtos.Earnings;
using api.Models;

namespace api.Interfaces
{
    public interface IEarningRepository
    {
        Task<List<EarningDto>> Get();
        Task<EarningDto> GetByIdAsync(int id);
        Task<Earning> CreateAsync(Earning earning);
        Task<Earning> UpdateAsync(int id, Earning earning);
        Task<Earning> DeleteAsync(int id);
        
    }
}
