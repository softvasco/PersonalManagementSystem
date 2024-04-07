using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.DebitCards
{
    public class CreateDebitCardDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}