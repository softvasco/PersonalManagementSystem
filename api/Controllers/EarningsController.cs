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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var earnings = await _earningRepository.Get();
                return Ok(earnings);
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

    }
}