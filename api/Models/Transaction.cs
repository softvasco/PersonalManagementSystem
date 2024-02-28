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
        
        public int? EarningId { get; set; }
        public Earning? Earning { get; set; }

        public int? ExpenseId { get; set; }
        public Expense? Expense { get; set; }

        public int? CreditId { get; set; }
        public Credit? Credit { get; set; }

        public int? SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 

        public byte[]? Attachment { get; set; } = [];
        
    }
}