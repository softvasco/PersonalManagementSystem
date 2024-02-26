using api.Dtos.Categories;
using api.Dtos.Users;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditsController : ControllerBase
    {
        private readonly ILogger<CreditsController> _logger;
        private readonly ICreditRepository _creditsRepository;

        public CreditsController(
            ICreditRepository creditsRepository,
            ILogger<CreditsController> logger)
        {
            _logger = logger;
            _creditsRepository = creditsRepository;
        }

       
    }
}
