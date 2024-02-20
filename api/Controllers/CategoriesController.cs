using api.Dtos.Categories;
using api.Dtos.Users;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(
            ICategoryRepository categoryRepository,
            ILogger<UsersController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = createCategoryDto.ToCategoryFromCreateCategoryDto();

            return Ok(await _categoryRepository.CreateAsync(categoryModel));
        }

    }
}
