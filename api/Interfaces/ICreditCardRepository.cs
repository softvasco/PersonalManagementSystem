using api.Models;

namespace api.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<CreditCard> CreateAsync(CreditCard creditCard);
    }
}
