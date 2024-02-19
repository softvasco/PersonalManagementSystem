﻿namespace api.Models
{
    public class FinanceGoal : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required decimal OutstandingAmount { get; set; }
        public required decimal CurrentDebtAmount { get; set; }
        public required decimal Goal { get; set; }

        public User User { get; set; }
    }
}