using api.Models;
using Shared.Dtos.OSRS;

namespace api.Interfaces
{
    public interface IOSRSRepository
    {
        Task<List<ProxyDto>> GetProxiesAsync();
        //Task<Weigth> CreateAsync(Weigth weigth);
        //Task<Weigth> UpdateAsync(int id, Weigth weigth);
        //Task<Weigth> DeleteAsync(int id);
    }
}
