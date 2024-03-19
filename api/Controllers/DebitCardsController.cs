using api.Dtos.DebitCards;
using api.Helpers;
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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var debitCards = await _debitCardRepository.Get();
                return Ok(debitCards);
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
        public async Task<IActionResult> Create([FromBody] CreateDebitCardDto createDebitCardsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var debitCardModel = createDebitCardsDto.ToDebitCardFromCreateDebitCardDto();
                await _debitCardRepository.CreateAsync(debitCardModel);

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
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateDebitCardDto updateDebitCardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var debitCard = updateDebitCardDto.ToDebitCardFromCreateDebitCardDto();
                await _debitCardRepository.UpdateAsync(id, debitCard);

                return Ok();
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

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var debitCard = await _debitCardRepository.DeleteAsync(id);

            if (debitCard == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}