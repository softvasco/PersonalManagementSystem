using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextoptions)
        : base(dbContextoptions)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TransactionFile> TransactionFiles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PersonalCredit> PersonalCredits { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

    }
}