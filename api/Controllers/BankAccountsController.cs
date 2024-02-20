using api.Dtos.BankAccounts;
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBankAccountDto createBankAccountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bankAccountModel = createBankAccountDto.ToBankAccountFromCreateBankAccountDto();

            return Ok(await _bankAccountRepository.CreateAsync(bankAccountModel));
        }

    }
}
