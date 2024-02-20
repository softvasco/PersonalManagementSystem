using api.Dtos.CreditCards;
using api.Models;

namespace api.Mappers
{
    public static class CreditCardMappers
    {
        public static CreditCard ToCreditCardFromCreateCreditCardDto(this CreateCreditCardsDto createCreditCardsDto)
        {
            return new CreditCard
            {
                Name = createCreditCardsDto.Name,
                Code = createCreditCardsDto.Code,
                Description = createCreditCardsDto.Description,
                Balance = createCreditCardsDto.Balance,
                CloseDate = createCreditCardsDto.CloseDate,
                OpenDate = createCreditCardsDto.OpenDate,
                IBAN = createCreditCardsDto.IBAN,
                UserId = createCreditCardsDto.UserId
            };
        }
    }
}