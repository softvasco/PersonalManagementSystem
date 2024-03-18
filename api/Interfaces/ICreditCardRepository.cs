using api.Dtos.CreditCards;
using api.Models;

namespace api.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<List<CreditCardDto>> Get();
        Task<CreditCard> CreateAsync(CreditCard creditCard);
        Task<CreditCard> UpdateAsync(int id, CreditCard creditCard);
        Task<CreditCard> DeleteAsync(int id);

    }
}