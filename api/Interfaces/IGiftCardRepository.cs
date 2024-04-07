using Shared.Dtos.GiftCards;
using api.Models;

namespace api.Interfaces
{
    public interface IGiftCardRepository
    {
        Task<List<GiftCardDto>> GetAsync(); 
        Task<GiftCard> CreateAsync(GiftCard giftCard);
        Task<GiftCard> UpdateAsync(int id, GiftCard giftCard);
        Task<GiftCard> DeleteAsync(int id);
    }
}
