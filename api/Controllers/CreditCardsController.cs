using Shared.Dtos.CreditCards;
using api.Helpers;
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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var creditCards = await _creditCardRepository.Get();
                return Ok(creditCards);
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
        public async Task<IActionResult> Create([FromBody] CreateCreditCardDto createCreditCardsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var creditCard = createCreditCardsDto.ToCreditCardFromCreateCreditCardDto();
                await _creditCardRepository.CreateAsync(creditCard);

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
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCreditCardDto updateCreditCardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var creditCard = updateCreditCardDto.ToCreditCardFromCreditCardDto();
                await _creditCardRepository.UpdateAsync(id, creditCard);

                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e);
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

            var bankAccount = await _creditCardRepository.DeleteAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return NoContent();
        }

      

    }
}
