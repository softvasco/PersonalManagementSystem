using api.Dtos.CreditCards;
using api.Dtos.DebitCards;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitCardsController : ControllerBase
    {
        private readonly ILogger<DebitCardsController> _logger;
        private readonly IDebitCardRepository _debitCardRepository;

        public DebitCardsController(
            IDebitCardRepository debitCardRepository,
            ILogger<DebitCardsController> logger)
        {
            _debitCardRepository = debitCardRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDebitCardsDto createDebitCardsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var debitCardModel = createDebitCardsDto.ToDebitCardFromCreateDebitCardDto();

            return Ok(await _debitCardRepository.CreateAsync(debitCardModel));
        }

    }
}
