using api.Dtos.Credits;
using api.Models;

namespace api.Mappers
{
    public static class CreditMappers
    {
        public static CreditDto ToCreditDtoFromCredit(this Credit credit)
        {
            return new CreditDto
            {
                Code = credit.Code,
                UserId = credit.UserId,
                CloseDate = credit.CloseDate,
                Description = credit.Description,
                OpenDate = credit.OpenDate,
            };
        }

        public static Credit ToCreditFromCreateCreditDto(this CreateCreditDto createCreditDto)
        {
            return new Credit
            {
                Code = createCreditDto.Code,
                UserId = createCreditDto.UserId,
                CloseDate = createCreditDto.CloseDate,
                Description = createCreditDto.Description,
                OpenDate = createCreditDto.OpenDate,
            };
        }

        public static Credit ToCreditFromUpdateCreditDto(this UpdateCreditDto updateCreditDto)
        {
            return new Credit
            {
                Code = updateCreditDto.Code,
                UserId = updateCreditDto.UserId,
                CloseDate = updateCreditDto.CloseDate,
                Description = updateCreditDto.Description,
                OpenDate = updateCreditDto.OpenDate,
            };
        }

    }
}