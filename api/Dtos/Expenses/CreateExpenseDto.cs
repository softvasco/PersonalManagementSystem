using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Expenses
{
    public class CreateExpenseDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; } = string.Empty;
        [Required]
        public List<int> Months { get; set; } = new List<int>();
        [Required]
        public int PayDay { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string SourceAccountOrCardCode { get; set; } = string.Empty;
        [Required]
        public string DestinationAccountOrCardCode { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }

    }
}