﻿using api.Dtos.Categories;
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
                Code = category.Code,
                Description = category.Description,
                UserId = category.UserId,
                SubCategories = category.SubCategories.Select(s => new SubcategoryDto
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