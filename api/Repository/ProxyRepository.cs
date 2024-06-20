using api.Data;
using api.Interfaces;
using api.Models;
using Shared.Dtos.OSRS;

namespace api.Repository
{
    public class ProxyRepository : IProxyRepository
    {
        private readonly ApplicationDBContext _context;

        public ProxyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AddProxiesDto addProxiesDto)
        {
            string[] _proxies = addProxiesDto.ProxiesInfo.Split('\n');

            List<OSRSProxy> lstOfOSRSProxies = [];

            foreach (string _proxy in _proxies)
            {

                try
                {
                    lstOfOSRSProxies.Add(new OSRSProxy()
                    {
                        CreatedDate = DateTime.Now,
                        IP = _proxy.Split(",")[0],
                        Port = _proxy.Split(",")[1],
                        IsActive = true,
                        Username = _proxy.Split(",")[2],
                        Password = _proxy.Split(",")[3],
                        UpdatedDate = DateTime.Now,
                    });
                }
                catch { }
            }

            await _context.OSRSProxies.AddRangeAsync(lstOfOSRSProxies);
            await _context.SaveChangesAsync();
        }
    }
}