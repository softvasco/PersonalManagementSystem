using System.ComponentModel.DataAnnotations;

namespace api.Dtos.BankAccounts
{
    public class CreateBankAccountDto
    {      
        public int Id { get; set; }
        public string? Number { get; set; } = string.Empty;
        
        public string? Swift { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        
        public string? Description { get; set; } = string.Empty;
        
        public string? IBAN { get; set; } = string.Empty;
        
        public string? NIB { get; set; } = string.Empty;
        
        public decimal Balance { get; set; }
        
        public DateTime? OpenDate { get; set; }

        [Required]
        public int UserId { get; set; }

        public IFormFile? File { get; set; } = null;
        public string FileName { get; set; } = string.Empty;

    }
}