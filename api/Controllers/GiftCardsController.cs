using api.Dtos.GiftCards;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiftCardsController : ControllerBase
    {
        private readonly ILogger<GiftCardsController> _logger;
        private readonly IGiftCardRepository _giftCardRepository;

        public GiftCardsController(
            IGiftCardRepository giftCardRepository,
            ILogger<GiftCardsController> logger)
        {
            _giftCardRepository = giftCardRepository;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGiftCardDto createGiftCardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var giftCard = createGiftCardDto.ToGiftCardFromCreateGiftCardDto();

            return Ok(await _giftCardRepository.CreateAsync(giftCard));
        }

    }
}
