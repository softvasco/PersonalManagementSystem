namespace api.Models
{
    public class DebitCard : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }
    }
}
