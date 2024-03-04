using System.ComponentModel.DataAnnotations;

namespace api.Dtos.BankAccounts
{
    public class UpdateBalanceCreditCardDto
    {
        [Required]
        public decimal Balance { get; set; }
    }
}