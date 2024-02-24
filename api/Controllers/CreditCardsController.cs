using api.Dtos.BankAccounts;
using api.Dtos.CreditCards;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repository;
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

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            try
            {
                var creditCard = await _creditCardRepository.GetByCodeAsync(code);
                return Ok(creditCard);
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
        public async Task<IActionResult> CreateAsync([FromForm] CreateCreditCardsDto createCreditCardsDto)
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
            catch
            {
                return BadRequest();
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

            var bankAccount = await _creditCardRepository.DeleteAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
