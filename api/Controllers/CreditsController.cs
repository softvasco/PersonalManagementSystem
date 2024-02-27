using api.Dtos.Credits;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repository;
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCreditDto createCreditDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var creditCard = createCreditDto.ToCreditFromCreateCreditDto();
                await _creditRepository.CreateAsync(creditCard);

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
                var earning = await _creditRepository.GetByCodeAsync(code);
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
