namespace api.Dtos.DebitCards
{
    public class DebitCardDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public int UserId { get; set; }
        public bool IsEditing { get; set; }
    }
}