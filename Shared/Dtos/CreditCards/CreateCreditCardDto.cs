using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.CreditCards
{
    public class CreateCreditCardDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? IBAN { get; set; } = string.Empty;
        public string? NIB { get; set; } = string.Empty;
        [Required]
        public decimal Balance { get; set; }
        public DateTime? OpenDate { get; set; }
        [Required]
        public int UserId { get; set; }
        public int? CloseExtractDay { get; set; } = 0;
        public string? EntityNumber { get; set; } = string.Empty;
        public string? RefNumber { get; set; } = string.Empty;
        public decimal Plafon { get; set; }
        public decimal PercentageOfPayment { get; set; }
    }
}