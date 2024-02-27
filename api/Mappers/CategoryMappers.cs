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
                Code = createCategoryDto.Code,
                Description = createCategoryDto.Description,
                AnnualPlafond = createCategoryDto.AnnualPlafon,
                UserId = createCategoryDto.UserID,
                MonthlyPlafond = createCategoryDto.MontlyPlafon,
                SubCategories = createCategoryDto.Subcategories.Select(s => new SubCategory
                {
                    Code = s.Code,
                    Description = s.Description,
                    AnnualPlafond = s.AnnualPlafon,
                    PaymentPercentagePerUser = s.PaymentPercentagePerUser,
                    MonthlyPlafond = s.MontlyPlafon,
                }).ToList()
            };
        }
    }
}