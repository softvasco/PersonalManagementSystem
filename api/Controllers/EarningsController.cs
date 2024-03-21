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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var earnings = await _earningRepository.GetAsync();
                return Ok(earnings);
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
        public async Task<IActionResult> Create([FromBody] CreateEarningDto createEarningDto)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEarningDto updateEarningDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var earning = updateEarningDto.ToEarningFromUpdateEarningDto();
                await _earningRepository.UpdateAsync(id, earning);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _earningRepository.DeleteAsync(id);

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