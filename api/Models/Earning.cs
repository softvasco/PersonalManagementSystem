
namespace api.Models
{
    public class Earning : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public decimal GrossAmountWithTaxes { get; set; }
        public decimal NetAmount { get; set; }
        public int Period { get; set; }
    }
}
