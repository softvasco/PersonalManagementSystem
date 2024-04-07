using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.SubCategories
{
    public class CreateSubCategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int CategoryId { get; set; }
        public decimal? MonthlyPlafond { get; set; }
        public decimal? AnnualPlafon { get; set; }
    }
}