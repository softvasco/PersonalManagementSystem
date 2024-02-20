using api.Dtos.Categories;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static Category ToCategoryFromCreateCategoryDto(this CreateCategoryDto createCategoryDto)
        {
            return new Category
            {
                AnnualPlafon = createCategoryDto.AnnualPlafon,
                Description = createCategoryDto.Description,
                MontlyPlafon = createCategoryDto.MontlyPlafon,
                Name = createCategoryDto.Name,
                User = createCategoryDto.User,
                StartDate = createCategoryDto.StartDate,
                ClosedDate = createCategoryDto.ClosedDate,
            };
        }
    }
}