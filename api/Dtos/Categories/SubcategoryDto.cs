using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Categories
{
    public class SubcategoryDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public decimal? MontlyPlafon { get; set; }
        public decimal? AnnualPlafon { get; set; }
        public decimal? PaymentPercentagePerUser { get; set; }
    }

}