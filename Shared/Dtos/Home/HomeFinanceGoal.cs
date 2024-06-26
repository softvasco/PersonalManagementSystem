﻿
namespace Shared.Dtos.Home
{
    public class HomeFinanceGoal
    {
        public DateTime StartGoalDate { get; set; }
        public DateTime? EndGoalDate { get; set; }
        public decimal OutstandingAmount { get; set; }
        public decimal DebtAmount { get; set; }
        public decimal Goal { get; set; }
        public decimal Diff { get; set; }
        public DateTime FinalDebtDate { get; set; }
    }
}