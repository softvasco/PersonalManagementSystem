using Shared.Dtos.DebitCards;
using api.Models;

namespace api.Interfaces
{
    public interface IDebitCardRepository
    {
        Task<List<DebitCardDto>> Get();
        Task<DebitCard> CreateAsync(DebitCard debitCard);
        Task<DebitCard> UpdateAsync(int id, DebitCard debitCard);
        Task<DebitCard> DeleteAsync(int id);
    }
}
