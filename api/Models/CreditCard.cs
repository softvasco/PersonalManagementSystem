namespace api.Models
{
    public class CreditCard : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required User User { get; set; }
        public required decimal Installment { get; set; }
        public required decimal OutstandingBalance { get; set; }
        public required decimal Plafon { get; set; }
        public required decimal Percentage { get; set; }
        public required DateTime StartDate { get; set; }
        public  DateTime? EndDate { get; set; }
    }
}