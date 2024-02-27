namespace api.Dtos.GiftCards
{
    public class GiftCardDto
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVoucher { get; set; }
        public string? CardNumer { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int UserId { get; set; }
    }
}