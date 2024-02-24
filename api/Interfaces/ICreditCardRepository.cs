using api.Dtos.CreditCards;
using api.Models;

namespace api.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<CreditCard> CreateAsync(CreditCard creditCard);
        Task<CreditCard> DeleteAsync(int id);
        Task<CreditCardDto> GetByCodeAsync(string code);
        Task<CreditCard> UpdateAsync(int id, CreditCard creditCard);
    }
}
