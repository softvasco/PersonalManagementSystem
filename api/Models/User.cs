namespace api.Models
{
    public class User: BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

    }
}
