namespace api.Models
{
    public class Category : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<SubCategory> SubCategories { get; set;}
    }
}