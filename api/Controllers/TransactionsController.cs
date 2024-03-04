using api.Dtos.BankAccounts;
using api.Dtos.Transactions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTransactionDto createTransactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var transaction = await createTransactionDto.ToTransactionFromCreateTransactionDto();
                await _transactionRepository.CreateAsync(transaction, createTransactionDto.IgnoreRules);

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

    }
}
