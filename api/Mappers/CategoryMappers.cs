using Shared.Dtos.Categories;
using Shared.Dtos.SubCategories;
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
                UserId = createCategoryDto.UserID,
                SubCategories = createCategoryDto.Subcategories.Select(s => new SubCategory
                {
                    Code = s.Code,
                    Description = s.Description,
                    AnnualPlafon = s.AnnualPlafon,
                    MonthlyPlafond = s.MonthlyPlafond,
                }).ToList()
            };
        }

        public static CategoryDto ToCategoryDtoFromCategory(this Category category)
        {
            return new CategoryDto
            {
                Id=category.Id,
                Code = category.Code,
                Description = category.Description,
                UserId = category.UserId,
                IsEditing=false,
                SubCategories = category.SubCategories.Select(s => new SubCategoryDto
                {
                    Code = s.Code,
                    Description = s.Description,
                    AnnualPlafon = s.AnnualPlafon,
                    MonthlyPlafond = s.MonthlyPlafond,
                }).ToList()
            };
        }

        public static Category ToCategoryFromupdateCategoryDto(this UpdateCategoryDto updateCategoryDto)
        {
            return new Category
            {
                Code = updateCategoryDto.Code,
                Description = updateCategoryDto.Description,
                UserId = updateCategoryDto.UserID,
                SubCategories = updateCategoryDto.Subcategories.Select(s => new SubCategory
                {
                    Code = s.Code,
                    Description = s.Description,
                    AnnualPlafon = s.AnnualPlafon,
                    MonthlyPlafond = s.MonthlyPlafond,
                }).ToList()
            };
        }
        
    }
}