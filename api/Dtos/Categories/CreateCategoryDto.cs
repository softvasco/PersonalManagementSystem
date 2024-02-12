using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public decimal MontlyPlafon { get; set; }
        [Required]
        public decimal AnnualPlafon { get; set; }
    }
}
