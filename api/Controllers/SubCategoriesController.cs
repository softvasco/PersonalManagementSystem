using api.Dtos.SubCategories;
using api.Helpers;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var subCategories = await _subCategoryRepository.GetAsync();
                return Ok(subCategories);
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
        public async Task<IActionResult> Create([FromBody] CreateSubCategoryDto createSubCategoryDto)
        {
            try
            {
                var subCategoryModel = createSubCategoryDto.TosubCategoryFromCreateSubCategoryDto();
                await _subCategoryRepository.CreateAsync(subCategoryModel);

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
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateSubCategoryDto updateSubCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var subCategory = updateSubCategoryDto.ToSubCategoryFromUpdateSubCategoryDto();
                await _subCategoryRepository.UpdateAsync(id, subCategory);

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
                await _subCategoryRepository.DeleteAsync(id);

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
