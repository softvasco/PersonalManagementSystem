﻿using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Expenses
{
    public class UpdateExpenseDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Months { get; set; } = string.Empty;
        [Required]
        public int PayDay { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string? SourceAccountOrCardCode { get; set; } = string.Empty;

        public string? DestinationAccountOrCardCode { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }

        public int SubCategoryId { get; set; }
    }
}