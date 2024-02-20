namespace api.Models
{
    public class PersonalCredit : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public decimal Installment { get; set; }
        public decimal OutstandingBalance { get; set; }
        public decimal TAN { get; set; }
        public decimal InitialDebt { get; set; }
    }
}