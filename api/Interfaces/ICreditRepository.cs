using Shared.Dtos.Credits;
using api.Models;

namespace api.Interfaces
{
    public interface ICreditRepository
    {
        Task<List<CreditDto>> Get();
        Task<Credit> CreateAsync(Credit credit);
    }
}
