namespace api.Models
{
    public class SubCategory : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? MonthlyPlafond { get; set; }
        public decimal? AnnualPlafon { get; set; }
        public bool IsVisibleInHomePage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();

    }
}