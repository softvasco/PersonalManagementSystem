namespace api.Models
{
    public class SubCategory : BaseEntity
    {
        public required string Name { get; set; }
        public string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required decimal MontlyPlafon { get; set; }
        public required decimal AnnualPlafon { get; set; }
        public required decimal Percentage { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
    }
}
