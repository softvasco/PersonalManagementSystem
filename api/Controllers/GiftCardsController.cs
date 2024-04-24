using Shared.Dtos.GiftCards;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bankAccounts = await _giftCardRepository.GetAsync();
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
        public async Task<IActionResult> Create([FromForm] CreateGiftCardDto createGiftCardDto)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateGiftCardDto updateGiftCardDto)
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

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bankAccount = await _giftCardRepository.DeleteAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
