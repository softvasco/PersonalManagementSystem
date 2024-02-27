
namespace api.Dtos.Credits
{
    public class CreateCreditDto
    {
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int UserId { get; set; }
    }
}