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
                    string[] _proxyParts = _proxy.Split(",");
                    string _ip = _proxyParts[0];
                    string _port = _proxyParts[1];
                    string _username = _proxyParts[2];
                    string _password = _proxyParts[3];

                    if (!_context.OSRSProxies.Any(p => p.IP == _ip))
                    {
                        lstOfOSRSProxies.Add(new OSRSProxy()
                        {
                            CreatedDate = DateTime.Now,
                            IP = _ip,
                            Port = _port,
                            IsActive = true,
                            Username = _username,
                            Password = _password,
                            UpdatedDate = DateTime.Now,
                        });
                    }
                }
                catch { }
            }

            await _context.OSRSProxies.AddRangeAsync(lstOfOSRSProxies);
            await _context.SaveChangesAsync();
        }
    }
}