using api.Models;
using Shared.Dtos.OSRS;

namespace api.Interfaces
{
    public interface IOSRSRepository
    {
        Task<List<ProxyDto>> GetProxiesAsync();
        //Task<Weigths> CreateAsync(Weigths weigth);
        //Task<Weigths> UpdateAsync(int id, Weigths weigth);
        //Task<Weigths> DeleteAsync(int id);
    }
}
