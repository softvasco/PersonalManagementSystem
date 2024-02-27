namespace api.Models
{
    public class CreditCard : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty ;
        public string? IBAN { get; set; } = string.Empty;
        public string? NIB { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public decimal Plafon { get;set; }
        public decimal PercentageOfPayment { get; set; }
        public string? EntityNumber {  get; set; }
        public string? RefNumber { get; set; }
        public int? CloseExtractDay { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 
    }
}
