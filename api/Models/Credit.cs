namespace api.Models
{
    public class Credit : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? AccountOrCardCodeToDebt { get; set; } = string.Empty;
        public decimal StartingCapital { get; set; }
        public decimal DebtCapital { get; set; }
        public decimal Installment { get; set; }
        public int PayDay { get; set; }
        public decimal TAN { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public byte[]? FileContent { get; set; }
    }
}
