using api.Dtos.Earnings;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EarningsController : ControllerBase
    {
        private readonly ILogger<EarningsController> _logger;
        private readonly IEarningRepository _earningRepository;

        public EarningsController(
            IEarningRepository earningRepository,
            ILogger<EarningsController> logger)
        {
            _earningRepository = earningRepository;
            _logger = logger;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            try
            {
                var earning = await _earningRepository.GetByCodeAsync(code);
                return Ok(earning);
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
        public async Task<IActionResult> CreateAsync([FromForm] CreateEarningDto createEarningDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var earning = createEarningDto.ToEarningFromCreateEarningDto();
                await _earningRepository.CreateAsync(earning);

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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateBankAccountDto updateBankAccountDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var bankAccount = await updateBankAccountDto.ToBankAccountFromUpdateBankAccountDto();
        //        await _bankAccountRepository.UpdateAsync(id, bankAccount);

        //        return Ok();
        //    }
        //    catch(NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        //[HttpDelete]
        //[Route("{id:int}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var bankAccount = await _bankAccountRepository.DeleteAsync(id);

        //    if (bankAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

    }
}
