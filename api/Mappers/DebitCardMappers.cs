using api.Dtos.DebitCards;
using api.Models;

namespace api.Mappers
{
    public static class DebitCardMappers
    {
        public static DebitCard ToDebitCardFromCreateDebitCardDto(this CreateDebitCardDto createDebitCardsDto)
        {
            return new DebitCard
            {
                Code = createDebitCardsDto.Code,
                Description = createDebitCardsDto.Description,
                Balance = createDebitCardsDto.Balance,
                CloseDate = createDebitCardsDto.CloseDate,
                OpenDate = createDebitCardsDto.OpenDate,
                UserId = createDebitCardsDto.UserId
            };
        }

        public static DebitCard ToDebitCardFromCreateDebitCardDto(this UpdateDebitCardDto updateDebitCardDto)
        {
            return new DebitCard
            {
                Code = updateDebitCardDto.Code,
                Description = updateDebitCardDto.Description,
                Balance = updateDebitCardDto.Balance,
                CloseDate = updateDebitCardDto.CloseDate,
                OpenDate = updateDebitCardDto.OpenDate,
                UserId = updateDebitCardDto.UserId
            };
        }

        public static DebitCardDto ToDebitCardDtoFromDebitCard(this DebitCard debitCard)
        {
            return new DebitCardDto
            {
                Id = debitCard.Id,
                Code = debitCard.Code,
                Description = debitCard.Description,
                Balance = debitCard.Balance,
                CloseDate = debitCard.CloseDate,
                OpenDate = debitCard.OpenDate,
                UserId = debitCard.UserId
            };
        }

    }
}