using api.Dtos.Earnings;
using api.Models;

namespace api.Interfaces
{
    public interface IEarningRepository
    {
        Task<Earning> CreateAsync(Earning earning);
        Task<EarningDto> GetByCodeAsync(string code);
    }
}
