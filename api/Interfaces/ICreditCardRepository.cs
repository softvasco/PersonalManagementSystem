using api.Dtos.CreditCards;
using api.Models;

namespace api.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<CreditCard> CreateAsync(CreditCard creditCard);
        Task<CreditCardDto> GetByCodeAsync(string code);
        Task<CreditCard> UpdateAsync(int id, CreditCard creditCard);
        Task<CreditCard> DeleteAsync(int id);
        Task<CreditCard> UpdateBalanceAsync(int id, decimal balance);
    }
}