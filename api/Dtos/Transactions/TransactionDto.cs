namespace api.Dtos.Transactions
{
    public class TransactionDto
    {
        public string Description { get; set; } = string.Empty;
        public int State { get; set; }
        public DateTime OperationDate { get; set; }
        public string? SourceAccountOrCardCode { get; set; } = string.Empty;
        public string? DestinationAccountOrCardCode { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int? EarningId { get; set; }
        public int? ExpenseId { get; set; }
        public int? CreditId { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }
    }
}