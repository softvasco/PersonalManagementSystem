using api.Models;

namespace api.Interfaces
{
    public interface IDebitCardRepository
    {
        Task<DebitCard> CreateAsync(DebitCard debitCard);
    }
}
