using Shared.Dtos.OSRS;

namespace api.Interfaces
{
    public interface IProxyRepository
    {
        Task CreateAsync(AddProxiesDto addProxiesDto);
    }
}
