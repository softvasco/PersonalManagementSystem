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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Vasco Silva", Email = "sprvasco@hotmail.com", UserName = "VascoSilva" },
                new User { Id = 2, Name = "Ana Massano", Email = "anamassano.20@gmail.com", UserName = "AnaMassano" }
            );

            var userVasco = Users.Find(1);

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Casa", Description = "Despesas da casa", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, EndDate = null, User = userVasco! },
               new Category { Id = 2, Name = "Carro", Description = "Despesas do carro", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, EndDate = null, User = userVasco! },
               new Category { Id = 3, Name = "Pessoal", Description = "Despesas pessoais", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, EndDate = null, User = userVasco! },
           );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }




        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TransactionFile> TransactionFiles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PersonalCredit> PersonalCredits { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<MortgageLoan> MortgageLoans { get; set; }
        public DbSet<FinanceGoal> FinanceGoals { get; set; }

    }
}