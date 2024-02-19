
namespace api.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required decimal MontlyPlafon { get; set; }
        public required decimal AnnualPlafon { get; set; }

        public User User { get; set; }
    }
}
