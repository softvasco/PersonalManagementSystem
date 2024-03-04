﻿using api.Dtos.Credits;
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
                CloseDate = credit.CloseDate,
                Description = credit.Description,
                OpenDate = credit.OpenDate,
                AccountOrCardCodeToDebt = credit.AccountOrCardCodeToDebt,
                DebtCapital = credit.DebtCapital,
                DebtDay = credit.PayDay,
                Installment = credit.Installment,
                StartingCapital = credit.StartingCapital,
                TAN = credit.TAN,
                UserId = credit.UserId
            };
        }

        public async static Task<Credit> ToCreditFromCreateCreditDto(this CreateCreditDto createCreditDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (createCreditDto.File is not null)
                {
                    await createCreditDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

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
                Attachment = fileContent,
                UserId = createCreditDto.UserId
            };
        }

        public async static Task<Credit> ToCreditFromUpdateCreditDto(this UpdateCreditDto updateCreditDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (updateCreditDto.File is not null)
                {
                    await updateCreditDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

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
                Attachment = fileContent,
                UserId = updateCreditDto.UserId
            };
        }

    }
}