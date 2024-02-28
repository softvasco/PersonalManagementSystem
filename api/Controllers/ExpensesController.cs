using api.Dtos.Expenses;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ILogger<ExpensesController> _logger;
        private readonly IExpenseRepository _expenseRepository;

        public ExpensesController(
            IExpenseRepository expenseRepository,
            ILogger<ExpensesController> logger)
        {
            _expenseRepository = expenseRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateExpenseDto createExpenseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var expense = createExpenseDto.ToExpenseFromCreateExpenseDtoAsync();
                await _expenseRepository.CreateAsync(expense);

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