using System.ComponentModel.DataAnnotations;

namespace api.Dtos.CreditCards
{
    public class CreateCreditCardsDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string IBAN { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}