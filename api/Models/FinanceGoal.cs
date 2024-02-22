
namespace api.Models
{
    public class FinanceGoal : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal CurrentDebtAmount { get; set; }
        public decimal Goal { get; set; }
        public DateTime StartGoalDate { get; set; }
        public DateTime? EndGoalDate { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

    }
}
