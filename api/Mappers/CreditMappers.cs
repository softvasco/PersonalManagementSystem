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
                Id = credit.Id,
                Code = credit.Code,
                CloseDate = credit.CloseDate,
                Description = credit.Description,
                OpenDate = credit.OpenDate,
                AccountOrCardCodeToDebt = credit.AccountOrCardCodeToDebt,
                DebtCapital = credit.DebtCapital,
                PayDay = credit.PayDay,
                Installment = credit.Installment,
                StartingCapital = credit.StartingCapital,
                TAN = credit.TAN,
                UserId = credit.UserId
            };
        }

        public static Credit ToCreditFromCreateCreditDto(this CreateCreditDto createCreditDto)
        {
            return new Credit
            {
                Code = createCreditDto.Code,
                CloseDate = createCreditDto.CloseDate,
                Description = createCreditDto.Description,
                OpenDate = createCreditDto.OpenDate,
                AccountOrCardCodeToDebt = createCreditDto.AccountOrCardCodeToDebt,
                TAN = createCreditDto.TAN,
                DebtCapital = createCreditDto.DebtCapital,
                PayDay = createCreditDto.PayDay,
                Installment = createCreditDto.Installment,
                StartingCapital = createCreditDto.StartingCapital,
                UserId = createCreditDto.UserId
            };
        }

        public static Credit ToCreditFromUpdateCreditDto(this UpdateCreditDto updateCreditDto)
        {
            return new Credit
            {
                Code = updateCreditDto.Code,
                CloseDate = updateCreditDto.CloseDate,
                Description = updateCreditDto.Description,
                OpenDate = updateCreditDto.OpenDate,
                AccountOrCardCodeToDebt = updateCreditDto.AccountOrCardCodeToDebt,
                TAN = updateCreditDto.TAN,
                DebtCapital = updateCreditDto.DebtCapital,
                PayDay = updateCreditDto.PayDay,
                Installment = updateCreditDto.Installment,
                StartingCapital = updateCreditDto.StartingCapital,
                UserId = updateCreditDto.UserId
            };
        }

    }
}