namespace api.Dtos.Categories
{
    public class CategoryDto
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserID { get; set; }
        public decimal? MontlyPlafon { get; set; }
        public decimal? AnnualPlafon { get; set; }

        public List<SubcategoryDto> Subcategories { get; set; }

    }
}