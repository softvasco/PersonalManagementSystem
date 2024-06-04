using Shared.Dtos.SubCategories;
using api.Models;

namespace api.Mappers
{
    public static class SubCategoryMappers
    {
        public static SubCategory TosubCategoryFromCreateSubCategoryDto(this CreateSubCategoryDto createSubCategoryDto)
        {
            return new SubCategory
            {
                Code = createSubCategoryDto.Code,
                Description = createSubCategoryDto.Description,
                CategoryId = createSubCategoryDto.CategoryId,
                MonthlyPlafond = createSubCategoryDto.MonthlyPlafond,
                AnnualPlafon = createSubCategoryDto.AnnualPlafon,
                IsVisibleInHomePage = true
            };
        }

        public static SubCategoryDto ToSubCategoryDtoFromSubCategory(this SubCategory subCategory)
        {
            return new SubCategoryDto
            {
                Id = subCategory.Id,
                Code = subCategory.Code,
                Description = subCategory.Description,
                IsEditing = false,
                AnnualPlafon = subCategory.AnnualPlafon,
                MonthlyPlafond = subCategory.MonthlyPlafond,
                CategoryName = subCategory.Category.Description,
                CategoryId = subCategory.CategoryId
            };
        }

        public static SubCategory ToSubCategoryFromUpdateSubCategoryDto(this UpdateSubCategoryDto updateSubCategoryDto)
        {
            return new SubCategory
            {
                Code = updateSubCategoryDto.Code,
                Description = updateSubCategoryDto.Description,
                CategoryId = updateSubCategoryDto.CategoryId,
                MonthlyPlafond = updateSubCategoryDto.MonthlyPlafond,
                AnnualPlafon = updateSubCategoryDto.AnnualPlafon,
            };
        }
        
    }
}