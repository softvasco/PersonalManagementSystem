namespace api.Models
{
    public class GiftCard : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVoucher { get; set; }
        public string? CardNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public byte[]? FileContent { get;  set; }
    }
}
