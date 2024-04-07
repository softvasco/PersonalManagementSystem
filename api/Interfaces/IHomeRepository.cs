using Shared.Dtos.Home;

namespace api.Interfaces
{
    public interface IHomeRepository
    {
        Task<HomeDto> GetAsync(int UserId, int year);
    }
}