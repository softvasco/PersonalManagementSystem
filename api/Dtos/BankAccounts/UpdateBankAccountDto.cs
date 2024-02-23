using System.ComponentModel.DataAnnotations;

namespace api.Dtos.BankAccounts
{
    public class UpdateBankAccountDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Swift { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IBAN { get; set; } = string.Empty;
        public string NIB { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}