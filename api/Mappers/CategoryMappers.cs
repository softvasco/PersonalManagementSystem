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
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                AnnualPlafond = createCategoryDto.AnnualPlafon,
                UserId = createCategoryDto.UserID,
                MonthlyPlafond = createCategoryDto.MontlyPlafon,
                Subcategories = createCategoryDto.Subcategories.Select(s => new Category
                {
                    Name = s.Name,
                    Description = s.Description,
                    AnnualPlafond = s.AnnualPlafon,
                    MonthlyPlafond = s.MontlyPlafon,
                    UserId = s.UserID,
                }).ToList()
            };
        }
    }
}