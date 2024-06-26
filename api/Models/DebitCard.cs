﻿namespace api.Models
{
    public class DebitCard : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 
    }
}