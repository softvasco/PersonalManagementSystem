using api.Dtos.CreditCards;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardsController : ControllerBase
    {
        private readonly ILogger<CreditCardsController> _logger;
        private readonly ICreditCardRepository _creditCardRepository;

        public CreditCardsController(
            ICreditCardRepository creditCardRepository,
            ILogger<CreditCardsController> logger)
        {
            _creditCardRepository = creditCardRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCreditCardsDto createCreditCardsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creditCardModel = createCreditCardsDto.ToCreditCardFromCreateCreditCardDto();

            return Ok(await _creditCardRepository.CreateAsync(creditCardModel));
        }

    }
}
