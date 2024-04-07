using Shared.Dtos.BankAccounts;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bankAccounts = await _bankAccountRepository.GetAsync();
                return Ok(bankAccounts);
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
        public async Task<IActionResult> Create([FromForm] CreateBankAccountDto createBankAccountDto)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateBankAccountDto updateBankAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bankAccount = await updateBankAccountDto.ToBankAccountFromUpdateBankAccountDto();
                await _bankAccountRepository.UpdateAsync(id, bankAccount);

                return Ok();
            }
            catch(NotFoundException)
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
