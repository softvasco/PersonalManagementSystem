using Shared.Dtos.Users;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;

        public UsersController(
            IUserRepository userRepository,
            ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                var userModel = createUserDto.ToUserFromCreateUserDto();
                await _userRepository.CreateAsync(userModel);

                return Created();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
