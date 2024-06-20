namespace api.Models
{
    public class OSRSAccount : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RSName { get; set; } = string.Empty;
        public string BankPin { get; set; } = string.Empty;


        public bool IsBanned { get; set; }

        public OSRSProxy? Proxy { get; set; }
    }
}