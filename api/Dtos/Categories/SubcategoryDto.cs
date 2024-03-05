namespace api.Dtos.Categories
{
    public class SubcategoryDto
    {
        public int Id { get; set; } 
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? MonthlyPlafond { get; set; }
        public decimal? AnnualPlafon { get; set; }
        public bool IsEditing { get; set; }
    }
}