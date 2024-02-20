using api.Dtos.FinanceGoals;
using api.Interfaces;
using api.Mappers;
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

            var financeGoalModel = createFinanceGoalDto.ToFinanceGoalFromCreateFinanceGoalDto();

            return Ok(await _financeGoalRepository.CreateAsync(financeGoalModel));
        }

    }
}
