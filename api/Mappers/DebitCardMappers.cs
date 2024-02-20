using api.Dtos.DebitCards;
using api.Models;

namespace api.Mappers
{
    public static class DebitCardMappers
    {
        public static DebitCard ToDebitCardFromCreateDebitCardDto(this CreateDebitCardsDto createDebitCardsDto)
        {
            return new DebitCard
            {
                Name = createDebitCardsDto.Name,
                Code = createDebitCardsDto.Code,
                Description = createDebitCardsDto.Description,
                Balance = createDebitCardsDto.Balance,
                CloseDate = createDebitCardsDto.CloseDate,
                OpenDate = createDebitCardsDto.OpenDate,
                IBAN = createDebitCardsDto.IBAN,
                UserId = createDebitCardsDto.UserId
            };
        }
    }
}