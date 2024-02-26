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
                Amount = earning.Amount,
                Code = earning.Code,
                Description = earning.Description,
                DestinationAccountOrCardCode = earning.DestinationAccountOrCardCode,
                EndDate = earning.EndDate,
                Months = earning.Months,
                PayDay = earning.PayDay,
                StartDate = earning.StartDate,
                UserId = earning.UserId,
                Percentage = earning.Percentage,
               
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
                Months = createEarningDto.Months,
                PayDay = createEarningDto.PayDay,
                StartDate = createEarningDto.StartDate,
                UserId = createEarningDto.UserId,
                Percentage = createEarningDto.Percentage
            };
        }
    }
}