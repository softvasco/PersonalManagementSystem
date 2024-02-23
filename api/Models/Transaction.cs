namespace api.Models
{
    public class Transaction : BaseEntity
    {

        

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
