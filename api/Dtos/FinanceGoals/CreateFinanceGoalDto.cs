using api.Models;

namespace api.Dtos.FinanceGoals
{
    public class CreateFinanceGoalDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal OutstandingAmount { get; set; }
        public decimal CurrentDebtAmount { get; set; }
        public decimal Goal { get; set; }

        public int UserId { get; set; }
    }
}
