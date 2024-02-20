
namespace api.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public decimal MontlyPlafon { get; set; }
        public decimal AnnualPlafon { get; set; }

        public User User { get; set; }
    }
}
