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
                NIB = creditCard.NIB,
                OpenDate = creditCard.OpenDate,
                UserId = creditCard.UserId,
                CloseExtractDay = creditCard.CloseExtractDay,
                EntityNumber = creditCard.EntityNumber,
                RefNumber = creditCard.RefNumber,
            };
        }

        public static CreditCard ToCreditCardFromCreateCreditCardDto(this CreateCreditCardsDto createCreditCardsDto)
        {
            return new CreditCard
            {
                Code = createCreditCardsDto.Code,
                Description = createCreditCardsDto.Description,
                Balance = createCreditCardsDto.Balance,
                CloseDate = createCreditCardsDto.CloseDate,
                OpenDate = createCreditCardsDto.OpenDate,
                IBAN = createCreditCardsDto.IBAN,
                UserId = createCreditCardsDto.UserId,
                CloseExtractDay = createCreditCardsDto.CloseExtractDay,
                EntityNumber = createCreditCardsDto.EntityNumber,
                NIB = createCreditCardsDto.NIB,
                RefNumber = createCreditCardsDto.RefNumber,
            };
        }

        public static CreditCard ToCreditCardFromCreditCardDto(this UpdateCreditCardDto updateCreditCardDto)
        {
            return new CreditCard
            {
                Code = updateCreditCardDto.Code,
                Description = updateCreditCardDto.Description,
                Balance = updateCreditCardDto.Balance,
                CloseDate = updateCreditCardDto.CloseDate,
                OpenDate = updateCreditCardDto.OpenDate,
                IBAN = updateCreditCardDto.IBAN,
                UserId = updateCreditCardDto.UserId,
                NIB = updateCreditCardDto.NIB,
                CloseExtractDay = updateCreditCardDto.CloseExtractDay,
                EntityNumber = updateCreditCardDto.EntityNumber,
                RefNumber = updateCreditCardDto.RefNumber,
            };
        }

    }
}