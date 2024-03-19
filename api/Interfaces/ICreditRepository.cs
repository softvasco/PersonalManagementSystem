using api.Dtos.Credits;
using api.Models;

namespace api.Interfaces
{
    public interface ICreditRepository
    {
        Task<List<CreditDto>> Get();
        Task<Credit> CreateAsync(Credit credit);
        Task<Credit> UpdateAsync(int id, Credit credit);
        Task<Credit> DeleteAsync(int id);
    }
}
