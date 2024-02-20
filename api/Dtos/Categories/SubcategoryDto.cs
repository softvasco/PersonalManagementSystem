using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Categories
{
    public class SubcategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal? MontlyPlafon { get; set; }
        [Required]
        public decimal? AnnualPlafon { get; set; }
    }

}