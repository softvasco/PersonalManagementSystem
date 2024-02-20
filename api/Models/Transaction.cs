namespace api.Models
{
    public class Transaction : BaseEntity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public User User { get; set; }
        public DateTime DateOfOperation { get; set; }
        public int TransactionState { get; set; }
        public List<TransactionFile>? TransactionFiles { get; set; }
        public BankAccount? SourceBankAccount { get; set; }
        public BankAccount? DestinationBankAccount { get; set; }
        public CreditCard? SourceCreditCard { get; set; }
        public CreditCard? DestinationCreditCard { get; set; }
        public PersonalCredit? PersonalCredit { get; set; }
        public MortgageLoan? MortgageLoan { get; set; }
        public DebitCard? DebitCard { get; set; }
    }
}