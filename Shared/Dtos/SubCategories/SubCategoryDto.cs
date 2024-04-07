namespace Shared.Dtos.SubCategories
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? MonthlyPlafond { get; set; }
        public decimal? AnnualPlafon { get; set; }
        public bool IsEditing { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}