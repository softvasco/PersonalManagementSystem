using api.Dtos.Dropdown;
using api.Enum;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DropdownController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IDropdownRepository _dropdownRepository;

        public DropdownController(
            IDropdownRepository dropdownRepository,
            ILogger<UsersController> logger)
        {
            _dropdownRepository = dropdownRepository;
            _logger = logger;
        }

        [HttpGet("GetTransactionsStates")]
        public IActionResult GetTransactionsStates()
        {
            try
            {
                List<DropdownDto> result = new List<DropdownDto>()
                {
                    new DropdownDto{Id=(int)TransactionState.Pending,Description=TransactionState.Pending.ToString()},
                    new DropdownDto{Id=(int)TransactionState.Finished,Description=TransactionState.Finished.ToString()}
                };

                return Ok(result);
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

        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories()
        {
            try
            {
                var result = await _dropdownRepository.GetSubCategories();

                return Ok(result);
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

    }
}
