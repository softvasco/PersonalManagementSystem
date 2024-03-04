using api.Dtos.BankAccounts;
using api.Dtos.GiftCards;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repository;
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
        public async Task<IActionResult> CreateAsync([FromForm] CreateGiftCardDto createGiftCardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var giftCard = await createGiftCardDto.ToGiftCardFromCreateGiftCardDto();
                await _giftCardRepository.CreateAsync(giftCard);

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

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            try
            {
                var giftCard = await _giftCardRepository.GetByCodeAsync(code);
                return Ok(giftCard);
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
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateGiftCardDto updateGiftCardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var giftcard = await updateGiftCardDto.ToGiftCardFromUpdateGiftCardDto();
                await _giftCardRepository.UpdateAsync(id, giftcard);

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
