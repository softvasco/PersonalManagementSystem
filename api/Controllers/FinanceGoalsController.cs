using api.Dtos.Earnings;
using api.Dtos.FinanceGoals;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceGoalsController : ControllerBase
    {
        private readonly ILogger<FinanceGoalsController> _logger;
        private readonly IFinanceGoalRepository _financeGoalRepository;

        public FinanceGoalsController(
            IFinanceGoalRepository financeGoalRepository,
            ILogger<FinanceGoalsController> logger)
        {
            _financeGoalRepository = financeGoalRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFinanceGoalDto createFinanceGoalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var financeGoalModel = createFinanceGoalDto.ToFinanceGoalFromCreateFinanceGoalDto();
                await _financeGoalRepository.CreateAsync(financeGoalModel);

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
                var earning = await _financeGoalRepository.GetByCodeAsync(code);
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
