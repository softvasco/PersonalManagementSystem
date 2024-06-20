using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.OSRS;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProxiesController : ControllerBase
    {
        private readonly ILogger<ProxiesController> _logger;
        private readonly IProxyRepository _proxyRepository;

        public ProxiesController(
            IProxyRepository proxyRepository,
            ILogger<ProxiesController> logger)
        {
            _proxyRepository = proxyRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddProxiesDto addProxiesDto)
        {
            try
            {
                await _proxyRepository.CreateAsync(addProxiesDto);

                return Created();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
