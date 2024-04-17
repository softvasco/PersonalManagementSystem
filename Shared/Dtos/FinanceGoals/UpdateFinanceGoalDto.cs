namespace Shared.Dtos.FinanceGoals
{
    public class UpdateFinanceGoalDto
    {
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal OutstandingAmount { get; set; }
        public decimal CurrentDebtAmount { get; set; }
        public decimal Goal { get; set; }
        public DateTime StartGoalDate { get; set; }
        public DateTime? EndGoalDate { get; set; }

        public int UserId { get; set; }
    }
}
