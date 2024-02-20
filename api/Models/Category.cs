namespace api.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? MonthlyPlafond { get; set; } 
        public decimal? AnnualPlafond { get; set; } 


        public User User { get; set; }
        public int UserId { get; set; }

        public Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<Category> Subcategories { get; set; }

    }
}