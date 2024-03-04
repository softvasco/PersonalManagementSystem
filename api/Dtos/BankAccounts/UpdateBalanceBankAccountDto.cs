using System.ComponentModel.DataAnnotations;

namespace api.Dtos.BankAccounts
{
    public class UpdateBalanceBankAccountDto
    {
        [Required]
        public decimal Balance { get; set; }
    }
}