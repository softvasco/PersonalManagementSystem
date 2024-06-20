using Shared.Dtos.OSRS;

namespace api.Interfaces
{
    public interface IOSRSRepository
    {
        Task<List<ProxyDto>> GetProxiesAsync();
    }
}
