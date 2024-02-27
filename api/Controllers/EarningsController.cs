using api.Dtos.Earnings;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EarningsController : ControllerBase
    {
        private readonly ILogger<EarningsController> _logger;
        private readonly IEarningRepository _earningRepository;

        public EarningsController(
            IEarningRepository earningRepository,
            ILogger<EarningsController> logger)
        {
            _earningRepository = earningRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateEarningDto createEarningDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var earning = createEarningDto.ToEarningFromCreateEarningDto();
                await _earningRepository.CreateAsync(earning);

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

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            try
            {
                var earning = await _earningRepository.GetByCodeAsync(code);
                return Ok(earning);
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