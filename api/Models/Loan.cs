namespace api.Models
{
    public class Loan : BaseEntity
    {

        

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
