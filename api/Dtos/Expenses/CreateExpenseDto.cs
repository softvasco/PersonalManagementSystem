using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Expenses
{
    public class CreateExpenseDto
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string? Description { get; set; } = string.Empty;
        [Required]
        public string Months { get; set; } = string.Empty;
        [Required]
        public int PayDay { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string? SourceAccountOrCardCode { get; set; } = string.Empty;
        public string? DestinationAccountOrCardCode { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }

    }
}