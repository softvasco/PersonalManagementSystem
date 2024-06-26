using Shared.Dtos.Transactions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(
            ITransactionRepository transactionRepository,
            ILogger<TransactionsController> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string? description,
            [FromQuery] string? state,
            [FromQuery] string? startDate,
            [FromQuery] string? endDate)
        {
            try
            {
                var transactions = await _transactionRepository.GetAsync(description, state, startDate, endDate);
                return Ok(transactions);
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

        [HttpGet("GetAsync/{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var transaction = await _transactionRepository.GetByIdAsync(id);

                if (transaction == null)
                {
                    return NotFound();
                }

                return Ok(transaction.ToUpdateTransactionDtoFromTransaction());
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
        public async Task<IActionResult> Create([FromForm] CreateTransactionDto createTransactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transaction = await createTransactionDto.ToTransactionFromCreateTransactionDto();
                await _transactionRepository.CreateAsync(transaction);

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
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateTransactionDto updateTransactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _transactionRepository.UpdateAsync(id, updateTransactionDto);

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

        [HttpPut("ConfirmTransaction/{id}")]
        public async Task<IActionResult> ConfirmTransaction(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _transactionRepository.ConfirmTransactionAsync(id);

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

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = await _transactionRepository.DeleteAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
