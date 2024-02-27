﻿using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        public string Code { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int UserID { get; set; }
        public decimal? MontlyPlafon { get; set; }
        public decimal? AnnualPlafon { get; set; }
        public decimal? PaymentPercentagePerUser { get; internal set; }


        public List<SubcategoryDto> Subcategories { get; set; }

    }
}