using api.Dtos.Users;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static User ToUserFromCreateUserDto(this CreateUserDto createUserDto)
        {
            return new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Username = createUserDto.Username
            };
        }
    }
}