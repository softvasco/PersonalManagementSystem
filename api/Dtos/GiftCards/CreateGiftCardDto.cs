using System.ComponentModel.DataAnnotations;

namespace api.Dtos.GiftCards
{
    public class CreateGiftCardDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsVoucher { get; set; }
        public string? CardNumber { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        [Required]
        public int UserId { get; set; }

        public IFormFile? File { get; set; } = null;
    }
}
