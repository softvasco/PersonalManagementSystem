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
                Id = creditCard.Id,
                Balance = creditCard.Balance,
                Code = creditCard.Code,
                Description = creditCard.Description,
                IBAN = creditCard.IBAN,
                NIB = creditCard.NIB,
                OpenDate = creditCard.OpenDate,
                UserId = creditCard.UserId,
                CloseExtractDay = creditCard.CloseExtractDay,
                EntityNumber = creditCard.EntityNumber,
                RefNumber = creditCard.RefNumber,
                Plafon = creditCard.Plafon,
                PercentageOfPayment = creditCard.PercentageOfPayment,
            };
        }

        public static CreditCard ToCreditCardFromCreateCreditCardDto(this CreateCreditCardDto createCreditCardsDto)
        {
            return new CreditCard
            {
                Id = createCreditCardsDto.Id,
                Code = createCreditCardsDto.Code,
                Description = createCreditCardsDto.Description,
                Balance = createCreditCardsDto.Balance,
                OpenDate = createCreditCardsDto.OpenDate,
                IBAN = createCreditCardsDto.IBAN,
                UserId = createCreditCardsDto.UserId,
                CloseExtractDay = createCreditCardsDto.CloseExtractDay,
                EntityNumber = createCreditCardsDto.EntityNumber,
                NIB = createCreditCardsDto.NIB,
                RefNumber = createCreditCardsDto.RefNumber,
                Plafon = createCreditCardsDto.Plafon,
                PercentageOfPayment = createCreditCardsDto.PercentageOfPayment,
            };
        }

        public static CreditCard ToCreditCardFromCreditCardDto(this UpdateCreditCardDto updateCreditCardDto)
        {
            return new CreditCard
            {
                Code = updateCreditCardDto.Code,
                Description = updateCreditCardDto.Description,
                Balance = updateCreditCardDto.Balance,
                OpenDate = updateCreditCardDto.OpenDate,
                IBAN = updateCreditCardDto.IBAN,
                UserId = updateCreditCardDto.UserId,
                NIB = updateCreditCardDto.NIB,
                CloseExtractDay = updateCreditCardDto.CloseExtractDay,
                EntityNumber = updateCreditCardDto.EntityNumber,
                RefNumber = updateCreditCardDto.RefNumber,
                Plafon = updateCreditCardDto.Plafon,
                PercentageOfPayment = updateCreditCardDto.PercentageOfPayment,
            };
        }

    }
}