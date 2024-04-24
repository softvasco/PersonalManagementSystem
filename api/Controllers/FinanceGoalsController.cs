using Shared.Dtos.FinanceGoals;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var financeGoals = await _financeGoalRepository.GetAsync();
                return Ok(financeGoals);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateFinanceGoalDto updateFinanceGoalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var financeGoal = updateFinanceGoalDto.ToFinanceGoalFromUpdateFinanceGoalDto();
                await _financeGoalRepository.UpdateAsync(id, financeGoal);

                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _financeGoalRepository.DeleteAsync(id);

                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
