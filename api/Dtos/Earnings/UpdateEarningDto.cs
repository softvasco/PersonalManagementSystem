using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Earnings
{
    public class UpdateEarningDto
    {
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
        [Required]
        public string DestinationAccountOrCardCode { get; set; } = string.Empty;
        [Required]
        public int UserId { get; set; }

    }
}