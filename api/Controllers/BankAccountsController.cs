using api.Dtos.BankAccounts;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountsController : ControllerBase
    {
        private readonly ILogger<BankAccountsController> _logger;
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountsController(
            IBankAccountRepository bankAccountRepository,
            ILogger<BankAccountsController> logger)
        {
            _bankAccountRepository = bankAccountRepository;
            _logger = logger;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            try
            {
                var bankAccount = await _bankAccountRepository.GetByCodeAsync(code);
                return Ok(bankAccount);
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateBankAccountDto createBankAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bankAccount = await createBankAccountDto.ToBankAccountFromCreateBankAccountDtoAsync();
                await _bankAccountRepository.CreateAsync(bankAccount);

                return Created();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBankAccountDto updateBankAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bankAccount = updateBankAccountDto.ToBankAccountFromUpdateBankAccountDto();
                await _bankAccountRepository.UpdateAsync(id, bankAccount);

                return Ok();
            }
            catch(NotFoundException e)
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

            var bankAccount = await _bankAccountRepository.DeleteAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
