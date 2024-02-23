using System.ComponentModel.DataAnnotations;

namespace api.Dtos.BankAccounts
{
    public class CreateBankAccountDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Number { get; set; } = string.Empty;
        [Required]
        public string Swift { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string IBAN { get; set; } = string.Empty;
        [Required]
        public string NIB { get; set; } = string.Empty;
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        [Required]
        public int UserId { get; set; }

        public IFormFile? File { get; set; } = null;

    }
}