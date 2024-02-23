using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
    }
}
