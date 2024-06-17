namespace api.Models
{
    public class OSRSProxy : BaseEntity
    {
        public string IP { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}