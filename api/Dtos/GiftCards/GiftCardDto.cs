namespace api.Dtos.GiftCards
{
    public class GiftCardDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsVoucher { get; set; }
        public string? CardNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int UserId { get; set; }
        public bool IsEditing { get; set; }
        public byte[]? FileBytes { get; set; }
        public string? FileName { get; set; } = string.Empty;
        public string? ContentType { get; set; } = string.Empty;
        public IFormFile? File { get; set; } = null;
    }
}