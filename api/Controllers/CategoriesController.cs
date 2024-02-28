using api.Dtos.Categories;
using api.Dtos.Users;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repository;
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
            try
            {
                var categoryModel = createCategoryDto.ToCategoryFromCreateCategoryDto();
                await _categoryRepository.CreateAsync(categoryModel);

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

        [HttpGet("GetByCodeAsync/{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            try
            {
                var category = await _categoryRepository.GetByCodeAsync(code);
                return Ok(category);
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

        [HttpGet("GetByUserIdAsync/{UserId}")]
        public async Task<IActionResult> GetByUserIdAsync(int UserId)
        {
            try
            {
                var categories = await _categoryRepository.GetByUserIdAsync(UserId);
                return Ok(categories);
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
