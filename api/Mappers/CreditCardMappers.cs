using api.Dtos.BankAccounts;
using api.Dtos.CreditCards;
using api.Models;

namespace api.Mappers
{
    public static class CreditCardMappers
    {
        public static CreditCardDto ToCreditCardDtoFromCreditCard(this CreditCard creditCard)
        {
            return new CreditCardDto
            {
                Balance = creditCard.Balance,
                CloseDate = creditCard.CloseDate,
                Code = creditCard.Code,
                Description = creditCard.Description,
                IBAN = creditCard.IBAN,
                Name = creditCard.Name,
                NIB = creditCard.NIB,
                OpenDate = creditCard.OpenDate
            };
        }

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

        public static CreditCard ToCreditCardFromCreditCardDto(this UpdateCreditCardDto updateCreditCardDto)
        {
            return new CreditCard
            {
                Name = updateCreditCardDto.Name,
                Code = updateCreditCardDto.Code,
                Description = updateCreditCardDto.Description,
                Balance = updateCreditCardDto.Balance,
                CloseDate = updateCreditCardDto.CloseDate,
                OpenDate = updateCreditCardDto.OpenDate,
                IBAN = updateCreditCardDto.IBAN,
                UserId = updateCreditCardDto.UserId
            };
        }

    }
}