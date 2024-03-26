using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimulatorController : ControllerBase
    {
        private readonly ILogger<SimulatorController> _logger;
        private readonly ISimulatorRepository _simulatorRepository;

        public SimulatorController(
            ISimulatorRepository simulatorRepository,
            ILogger<SimulatorController> logger)
        {
            _simulatorRepository = simulatorRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Simulate(DateTime untilDate)
        {
            try
            {
                var result = await _simulatorRepository.SimulateAsync(untilDate);
                return Ok(result);
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
