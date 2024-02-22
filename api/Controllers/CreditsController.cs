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
        //private readonly ICategoryRepository _categoryRepository;

        public CreditsController(
            //ICategoryRepository categoryRepository,
            ILogger<CreditsController> logger)
        {
            //_categoryRepository = categoryRepository;
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var userModel = createCategoryDto.ToCategoryFromCreateCategoryDto();

        //    return Ok(await _categoryRepository.CreateAsync(userModel));
        //}

    }
}
