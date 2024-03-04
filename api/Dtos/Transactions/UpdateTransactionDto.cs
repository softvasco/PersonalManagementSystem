﻿using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Transactions
{
    public class UpdateTransactionDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int State { get; set; }
        [Required]
        public DateTime OperationDate { get; set; }
        public string? SourceAccountOrCardCode { get; set; } = string.Empty;
        public string? DestinationAccountOrCardCode { get; set; } = string.Empty;

        [Required]
        public decimal Amount { get; set; }

        public int? EarningId { get; set; }

        public int? ExpenseId { get; set; }

        public int? CreditId { get; set; }

        [Required]
        public int UserId { get; set; }
        public int? SubCategoryId { get; set; }

        public IFormFile? File { get; set; } = null;

        public bool IgnoreRules { get; set; }

    }
}