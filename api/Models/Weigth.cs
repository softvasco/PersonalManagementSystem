namespace api.Models
{
    public class Weigth : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public decimal Kg { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}