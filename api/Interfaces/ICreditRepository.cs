using api.Dtos.Credits;
using api.Models;

namespace api.Interfaces
{
    public interface ICreditRepository
    {
        Task<Credit> CreateAsync(Credit credit);
        Task<CreditDto> GetByCodeAsync(string code);
        Task<Credit> UpdateAsync(int id, Credit credit);
        Task<Credit> DeleteAsync(int id);
    }
}
