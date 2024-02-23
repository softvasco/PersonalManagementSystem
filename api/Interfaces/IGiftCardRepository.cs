using api.Models;

namespace api.Interfaces
{
    public interface IGiftCardRepository
    {
        Task<GiftCard> CreateAsync(GiftCard giftCard);
    }
}
