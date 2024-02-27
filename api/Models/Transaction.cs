namespace api.Models
{
    public class Transaction : BaseEntity
    {
        public string? Description { get; set; } = string.Empty;
        public int State { get; set; }
        public DateTime OperationDate { get; set; }
        public string? SourceAccountOrCardCode { get; set; } = string.Empty;
        public string? DestinationAccountOrCardCode { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal FinalAmount { get; set; }

        public int? EarningId { get; set; }
        public Earning? Earning { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 

        public byte[]? Attachment { get; set; } = [];

    }
}