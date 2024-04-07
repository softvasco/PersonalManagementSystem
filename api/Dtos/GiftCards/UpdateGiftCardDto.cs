using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.GiftCards
{
    public class UpdateGiftCardDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string? CardNumber { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public int UserId { get; set; }
        public byte[]? FileBytes { get; set; }
        public string? FileName { get; set; } = string.Empty;
        public string? ContentType { get; set; } = string.Empty;
        public IFormFile? File { get; set; } = null;
    }
}
