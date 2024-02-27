using api.Dtos.DebitCards;
using api.Models;

namespace api.Interfaces
{
    public interface IDebitCardRepository
    {
        Task<DebitCard> CreateAsync(DebitCard debitCard);
        Task<DebitCardDto> GetByCodeAsync(string code);
        Task<DebitCard> UpdateAsync(int id, DebitCard debitCard);
        Task<DebitCard> DeleteAsync(int id);
    }
}
