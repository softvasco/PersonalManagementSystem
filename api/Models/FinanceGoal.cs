namespace api.Models
{
    public class FinanceGoal : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required User User { get; set; }
    }
}