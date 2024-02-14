namespace api.Models
{
    public class MortgageLoan : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required User User { get; set; }
        public required decimal Installment { get; set; }
        public required decimal OutstandingBalance { get; set; }
    }
}