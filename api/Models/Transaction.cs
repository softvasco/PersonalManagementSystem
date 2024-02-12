namespace api.Models
{
    public class Transaction : BaseEntity
    {
        public required User User { get; set; }
        public Expense? Expense { get; set; }
        public Earning? Earning { get; set; }

        public required DateTime DateOfOperation { get; set; }
        public required int TransactionState { get; set; }
        public List<TransactionFile>? TransactionFiles { get; set; }

    }
}
