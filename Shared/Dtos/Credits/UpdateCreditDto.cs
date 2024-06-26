﻿
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Credits
{
    public class UpdateCreditDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string AccountOrCardCodeToDebt { get; set; } = string.Empty;
        [Required]
        public decimal StartingCapital { get; set; }
        [Required]
        public decimal DebtCapital { get; set; }
        public decimal Installment { get; set; }
        [Required]
        public int PayDay { get; set; }
        [Required]
        public decimal TAN { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}