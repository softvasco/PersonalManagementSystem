using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Categories
{
    public class SubcategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal? MontlyPlafon { get; set; }
        public decimal? AnnualPlafon { get; set; }
        public decimal? PaymentPercentagePerUser { get;  set; }
        public int UserID { get;  set; }
    }

}