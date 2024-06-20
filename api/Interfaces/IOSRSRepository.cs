using Shared.Dtos.OSRS;

namespace api.Interfaces
{
    public interface IOSRSRepository
    {
        Task CreateAsync(AddOSRSAccountsDto addOSRSAccountsDto);
        //Task<List<ProxyDto>> GetProxiesAsync();
    }
}
