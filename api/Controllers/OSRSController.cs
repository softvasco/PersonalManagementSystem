using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OSRSController : ControllerBase
    {
        private readonly ILogger<OSRSController> _logger;
        private readonly IOSRSRepository _oSRSRepository;

        public OSRSController(
            IOSRSRepository oSRSRepository,
            ILogger<OSRSController> logger)
        {
            _oSRSRepository = oSRSRepository;
            _logger = logger;
        }

        [HttpGet("GetProxies")]
        public async Task<IActionResult> GetProxies()
        {
            try
            {
                var proxies = await _oSRSRepository.GetProxiesAsync();
                return Ok(proxies);
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

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateWeigthDto createWeigthDto)
        //{
        //    try
        //    {
        //        var weigthModel = createWeigthDto.ToWeigthFromCreateWeigthDto();
        //        await _weightRepository.CreateAsync(weigthModel);

        //        return Created();
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateWeigthDto updateWeigthDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var weigth = updateWeigthDto.ToWeigthFromUpdateWeigthDto();
        //        await _weightRepository.UpdateAsync(id, weigth);

        //        return Ok();
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        await _weightRepository.DeleteAsync(id);

        //        return Ok();
        //    }
        //    catch (NotFoundException)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

    }
}
