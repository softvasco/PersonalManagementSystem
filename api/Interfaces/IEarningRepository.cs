using Shared.Dtos.Earnings;
using api.Models;

namespace api.Interfaces
{
    public interface IEarningRepository
    {
        Task<List<EarningDto>> GetAsync();
        Task<Earning> CreateAsync(Earning earning);
        Task<Earning> UpdateAsync(int id, Earning earning);
        Task<Earning> DeleteAsync(int id);
        
    }
}
