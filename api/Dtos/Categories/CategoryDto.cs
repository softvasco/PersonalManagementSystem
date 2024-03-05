﻿namespace api.Dtos.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public bool IsEditing { get; set; }
        public List<SubcategoryDto> SubCategories { get; set; }
    }
}