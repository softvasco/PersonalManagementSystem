using api.Dtos.Credits;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditsController : ControllerBase
    {
        private readonly ILogger<CreditsController> _logger;
        private readonly ICreditRepository _creditRepository;

        public CreditsController(
            ICreditRepository creditRepository,
            ILogger<CreditsController> logger)
        {
            _logger = logger;
            _creditRepository = creditRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var credits = await _creditRepository.Get();
                return Ok(credits);
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
        public async Task<IActionResult> Create([FromBody] CreateCreditDto createCreditDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var credit = createCreditDto.ToCreditFromCreateCreditDto();
                await _creditRepository.CreateAsync(credit);

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
