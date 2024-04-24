using Shared.Dtos.Categories;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeigthsController : ControllerBase
    {
        private readonly ILogger<WeigthsController> _logger;
        private readonly IWeightRepository _weightRepository;

        public WeigthsController(
            IWeightRepository weightRepository,
            ILogger<WeigthsController> logger)
        {
            _weightRepository = weightRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var weigths = await _weightRepository.GetAsync();
                return Ok(weigths);
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
        public async Task<IActionResult> Create([FromBody] CreateWeigthDto createWeigthDto)
        {
            try
            {
                var weigthModel = createWeigthDto.ToWeigthFromCreateWeigthDto();
                await _weightRepository.CreateAsync(weigthModel);

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
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateWeigthDto updateWeigthDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var weigth = updateWeigthDto.ToWeigthFromUpdateWeigthDto();
                await _weightRepository.UpdateAsync(id, weigth);

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
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _weightRepository.DeleteAsync(id);

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
