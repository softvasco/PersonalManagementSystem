namespace Shared.Dtos.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int? State { get; set; }
        public string? StateDesc { get; set; } = string.Empty;
        public DateTime OperationDate { get; set; }
        public string? SourceAccountOrCardCode { get; set; } = string.Empty;
        public string? DestinationAccountOrCardCode { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public int? EarningId { get; set; }
        public int? ExpenseId { get; set; }
        public int? CreditId { get; set; }
        public int SubCategoryId { get; set; }

        public string? FileName { get; set; } = string.Empty;
        public string? ContentType { get; set; } = string.Empty;
        public byte[]? FileBytes { get; set; } = Array.Empty<byte>();
    }
}