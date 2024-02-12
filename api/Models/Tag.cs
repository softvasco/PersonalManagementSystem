namespace api.Models
{
    public class Tag : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}