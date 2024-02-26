namespace api.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? MonthlyPlafond { get; set; }
        public decimal? AnnualPlafond { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 

        public Category ParentCategory { get; set; }
        public int ParentCategoryId { get; set; }

        public ICollection<Category> Subcategories { get; set; } 

    }
}