namespace api.Models
{
    public class BankAccount : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<User> Users { get; set; }
        public required string IBAN { get; set; }
        public required DateTime OpenDate { get; set; }
        public DateTime? Closed { get; set; }
        public required int Balance { get; set; }
    }
}
