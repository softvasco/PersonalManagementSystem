namespace api.Models
{
    public class Expense : BaseEntity
    {
        public required User User { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required decimal Amount { get; set; }
        public required int Period { get; set; }
    }
}
