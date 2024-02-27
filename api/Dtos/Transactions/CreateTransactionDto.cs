using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Transactions
{
    public class CreateTransactionDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        
       

        [Required]
        public int UserId { get; set; }

        public IFormFile? File { get; set; } = null;
    }
}
