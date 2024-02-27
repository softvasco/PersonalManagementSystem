using api.Dtos.GiftCards;
using api.Models;

namespace api.Interfaces
{
    public interface IGiftCardRepository
    {
        Task<GiftCard> CreateAsync(GiftCard giftCard);
        Task<GiftCardDto> GetByCodeAsync(string code);
        Task<GiftCard> UpdateAsync(int id, GiftCard giftCard);
        Task<GiftCard> DeleteAsync(int id);
    }
}
