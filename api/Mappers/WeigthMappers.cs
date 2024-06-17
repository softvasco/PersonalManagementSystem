using Shared.Dtos.Weigth;
using api.Models;

namespace api.Mappers
{
    public static class WeigthMappers
    {
        public static Weigth ToWeigthFromCreateWeigthDto(this CreateWeigthDto createWeigthDto)
        {
            return new Weigth
            {
               Description = createWeigthDto.Description,
               Kg = createWeigthDto.Kg,
               RegistrationDate = createWeigthDto.RegistrationDate,
               UserId = createWeigthDto.UserId,
               CreatedDate = DateTime.Now,
               IsActive = true,
               UpdatedDate = DateTime.Now,
            };
        }

        public static Weigth ToWeigthFromUpdateWeigthDto(this UpdateWeigthDto updateWeigthDto)
        {
            return new Weigth
            {
                Id = updateWeigthDto.Id,
                Description = updateWeigthDto.Description,
                Kg = updateWeigthDto.Kg,
                RegistrationDate = updateWeigthDto.RegistrationDate,
                UserId = updateWeigthDto.UserId,
                CreatedDate = DateTime.Now,
                IsActive = true,
                UpdatedDate = DateTime.Now,
            };
        }

        public static WeigthDto ToWeigthDtoFromWeigth(this Weigth weigth)
        {
            return new WeigthDto
            {
                Id = weigth.Id,
                Description = weigth.Description,
                Kg = weigth.Kg,
                RegistrationDate = weigth.RegistrationDate,
                UserId= weigth.UserId,
            };
        }
    }
}