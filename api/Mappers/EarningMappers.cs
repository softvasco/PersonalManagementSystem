using api.Dtos.Earnings;
using api.Models;

namespace api.Mappers
{
    public static class EarningMappers
    {
        public static EarningDto ToEarningDtoFromEarning(this Earning earning)
        {
            return new EarningDto
            {
                Id = earning.Id,
                Amount = earning.Amount,
                Code = earning.Code,
                Description = earning.Description,
                DestinationAccountOrCardCode = earning.DestinationAccountOrCardCode,
                EndDate = earning.EndDate,
                Months = string.Join(", ", earning.Months),
                PayDay = earning.PayDay,
                StartDate = earning.StartDate,
                UserId = earning.UserId

            };
        }

        public static Earning ToEarningFromCreateEarningDto(this CreateEarningDto createEarningDto)
        {
            return new Earning
            {
                Amount = createEarningDto.Amount,
                Code = createEarningDto.Code,
                Description = createEarningDto.Description,
                DestinationAccountOrCardCode = createEarningDto.DestinationAccountOrCardCode,
                EndDate = createEarningDto.EndDate,
                Months = createEarningDto.Months.ToString()!.Split(',').Select(int.Parse).ToList(),
                PayDay = createEarningDto.PayDay,
                StartDate = createEarningDto.StartDate,
                UserId = createEarningDto.UserId
            };
        }

        public static Earning ToEarningFromUpdateEarningDto(this UpdateEarningDto updateEarningDto)
        {
            return new Earning
            {
                Amount = updateEarningDto.Amount,
                Code = updateEarningDto.Code,
                Description = updateEarningDto.Description,
                DestinationAccountOrCardCode = updateEarningDto.DestinationAccountOrCardCode,
                EndDate = updateEarningDto.EndDate,
                Months = updateEarningDto.Months.Split(',').Select(int.Parse).ToList(),
                PayDay = updateEarningDto.PayDay,
                StartDate = updateEarningDto.StartDate,
                UserId = updateEarningDto.UserId
            };
        }

    }
}