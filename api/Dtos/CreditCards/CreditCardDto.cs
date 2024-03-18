
namespace api.Dtos.CreditCards
{
    public class CreditCardDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? IBAN { get; set; } = string.Empty;
        public string? NIB { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int UserId { get; set; }
        public int? CloseExtractDay { get; set; } = 0;
        public string? EntityNumber { get; set; } = string.Empty;
        public string? RefNumber { get; set; } = string.Empty;
        public decimal Plafon { get; set; }
        public decimal PercentageOfPayment { get; set; }
        public bool IsEditing { get; set; }
    }
}