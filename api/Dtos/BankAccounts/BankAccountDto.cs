namespace Shared.Dtos.BankAccounts
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string? Number { get; set; } = string.Empty;
        public string? Swift { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? IBAN { get; set; } = string.Empty;
        public string? NIB { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime? OpenDate { get; set; }
        public IFormFile? File { get; set; } = null;
        public int UserId { get; set; }
        public bool IsEditing { get; set; }

        public string? FileName { get; set; } = string.Empty;
        public string? ContentType { get; set; } = string.Empty;
        public byte[]? FileBytes { get; set; } = Array.Empty<byte>();

    }
}