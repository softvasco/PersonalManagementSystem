using api.Dtos.Categories;
using api.Dtos.Users;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ILogger<SubCategoriesController> _logger;
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoriesController(
            ISubCategoryRepository subCategoryRepository,
            ILogger<SubCategoriesController> logger)
        {
            _subCategoryRepository = subCategoryRepository;
            _logger = logger;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetByName([FromHeader] string categoryName)
        //{
        //    return Ok(await _categoryRepository.GetByName(categoryName));
        //}

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
