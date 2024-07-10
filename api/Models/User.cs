namespace api.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}