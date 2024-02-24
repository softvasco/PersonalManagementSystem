namespace api.Models
{
    public class Credit : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty ;
       
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }
    }
}
