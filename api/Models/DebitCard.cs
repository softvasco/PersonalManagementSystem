namespace api.Models
{
    public class DebitCard : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}