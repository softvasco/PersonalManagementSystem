namespace api.Models
{
    public class Earning : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int> Months { get; set; } = new List<int>();
        public int PayDay { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public string DestinationAccountOrCardCode { get; set; } = string.Empty;

        public User User { get; set; } 
        public int UserId { get; set; }

    }
}
