namespace api.Models
{
    public class Loan : BaseEntity
    {

        
        public int UserId { get; set; }
        public User User { get; set; } 
    }
}
