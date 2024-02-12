using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string username);
        Task<User> CreateAsync(User user);
    }
}
