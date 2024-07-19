using System.ComponentModel.DataAnnotations;
using Shared.Dtos.SubCategories;

namespace Shared.Dtos.Categories
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int UserID { get; set; }

        public List<SubCategoryDto> Subcategories { get; set; } = [];

    }
}