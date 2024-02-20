using api.Enum;
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
           // modelBuilder.Entity<User>().HasData(
           //     new User { Id = 1, Name = "Vasco Silva", Email = "sprvasco@hotmail.com", UserName = "VascoSilva" },
           //     new User { Id = 2, Name = "Ana Massano", Email = "anamassano.20@gmail.com", UserName = "AnaMassano" }
           // );

           // var userVasco = Users.Find(1);

           // modelBuilder.Entity<Category>().HasData(
           //    new Category { Id = 1, Name = "Casa", Description = "Despesas da casa", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, ClosedDate = null, User = userVasco! },
           //    new Category { Id = 2, Name = "Carro", Description = "Despesas do carro", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, ClosedDate = null, User = userVasco! },
           //    new Category { Id = 3, Name = "Gatos", Description = "Despesas dos gatos", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, ClosedDate = null, User = userVasco! },
           //    new Category { Id = 4, Name = "Pessoal", Description = "Despesas pessoais", MontlyPlafon = 0, AnnualPlafon = 0, StartDate = DateTime.Now, ClosedDate = null, User = userVasco! }
           //);

           // var categoryCasa = Categories.Find(1);
           // var categoryCarro = Categories.Find(2);
           // var categoryGatos = Categories.Find(3);
           // var categoryPessoal = Categories.Find(4);

           // modelBuilder.Entity<SubCategory>().HasData(
           //     new SubCategory { Id = 1, Name = "Água", Description = "Água", MontlyPlafon = 40, AnnualPlafon = 480, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 2, Name = "Luz", Description = "Luz", MontlyPlafon = 75, AnnualPlafon = 900, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 3, Name = "Meo Casa", Description = "Serviço TV NET VOZ", MontlyPlafon = (decimal)29.99, AnnualPlafon = (decimal)359.88, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 4, Name = "Condomínio", Description = "Condomínio", MontlyPlafon = 30, AnnualPlafon = 360, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 5, Name = "Seguro Vida", Description = "Seguro Vida - Crédito Habitação", MontlyPlafon = (decimal)16.94, AnnualPlafon = (decimal)203.28, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 6, Name = "Crédito Habitação", Description = "Crédito Habitação", MontlyPlafon = (decimal)559.4, AnnualPlafon = (decimal)6712.8, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 7, Name = "Seguro multi riscos", Description = "Seguro multi riscos", MontlyPlafon = 20, AnnualPlafon = 240, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 8, Name = "Comida", Description = "Compras extra cartão refeição", MontlyPlafon = 50, AnnualPlafon = 600, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCasa!, Percentage = 1 },

           //     new SubCategory { Id = 9, Name = "Gasolina", Description = "Gasolina", MontlyPlafon = 60, AnnualPlafon = 720, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCarro!, Percentage = 1 },
           //     new SubCategory { Id = 10, Name = "Revisão", Description = "Revisão", MontlyPlafon = 35, AnnualPlafon = 420, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCarro!, Percentage = 1 },
           //     new SubCategory { Id = 11, Name = "Inspeção", Description = "Inspeção", MontlyPlafon = 3, AnnualPlafon = 36, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCarro!, Percentage = 1 },
           //     new SubCategory { Id = 12, Name = "IUC", Description = "IUC", MontlyPlafon = (decimal)9.08, AnnualPlafon = 109, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCarro!, Percentage = 1 },
           //     new SubCategory { Id = 13, Name = "Seguro", Description = "Seguro automóvel", MontlyPlafon = (decimal)33.33, AnnualPlafon = 400, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryCarro!, Percentage = 1 },

           //     new SubCategory { Id = 14, Name = "Vacina", Description = "Vacinas", MontlyPlafon = 5, AnnualPlafon = 60, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryGatos!, Percentage = 1 },
           //     new SubCategory { Id = 15, Name = "Comida", Description = "Comida", MontlyPlafon = 720, AnnualPlafon = 60, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryGatos!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 16, Name = "Areia", Description = "Areia", MontlyPlafon = (decimal)43.8, AnnualPlafon = (decimal)525.6, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryGatos!, Percentage = (decimal)0.5 },
           //     new SubCategory { Id = 17, Name = "Desparasitação", Description = "Desparasitação interna", MontlyPlafon = (decimal)4.6, AnnualPlafon = 56, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryGatos!, Percentage = 1 },

           //     new SubCategory { Id = 18, Name = "Meo Pessoal", Description = "Telemóvel", MontlyPlafon = 10, AnnualPlafon = 120, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryPessoal!, Percentage = 1 },
           //     new SubCategory { Id = 19, Name = "Meo Internet móvel", Description = "Meo Internet móvel", MontlyPlafon = 16, AnnualPlafon = 192, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryPessoal!, Percentage = 1 },
           //     new SubCategory { Id = 20, Name = "LigaT", Description = "LigaT", MontlyPlafon = 15, AnnualPlafon = 180, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryPessoal!, Percentage = 1 },
           //     new SubCategory { Id = 21, Name = "OSRS", Description = "Subscrição OSRS", MontlyPlafon = 10, AnnualPlafon = 120, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryPessoal!, Percentage = 1 },
           //     new SubCategory { Id = 22, Name = "Saúde", Description = "Atos médicos", MontlyPlafon = (decimal)16.66, AnnualPlafon = 200, StartDate = DateTime.Now, EndDate = null, User = userVasco!, Category = categoryPessoal!, Percentage = 1 }

           // );

           // modelBuilder.Entity<FinanceGoal>().HasData(
           //    new FinanceGoal { Id = 1, Name = "Reduzir divida", Description = "Estimativa de objectivo de dívida de 40k a 01/01/2025", StartDate = new DateTime(2024, 01, 01), EndDate = new DateTime(2024, 12, 31), User = userVasco!, OutstandingAmount = 69000, CurrentDebtAmount = 69000, Goal = 40000 }
           // );

           // modelBuilder.Entity<MortgageLoan>().HasData(
           //   new MortgageLoan { Id = 1, Name = "Crédito Habitação - Bankinter", Description = "Crédito Habitação - Bankinter", User = userVasco!, Installment = (decimal)559.4, OutstandingBalance = 171000 }
           // );

           // modelBuilder.Entity<BankAccount>().HasData(
           //    new BankAccount { Id = 1, Name = "Banco CTT", Description = "Banco CTT", IBAN = "PT50 00XX", Balance = -3450, OpenDate = new DateTime(2015, 09, 01), ClosedDate = null, User = userVasco! },
           //    new BankAccount { Id = 2, Name = "Bankinter", Description = "Bankinter", IBAN = "PT50 00XX", Balance = 0, OpenDate = new DateTime(2022, 07, 01), ClosedDate = null, User = userVasco! }
           // );

           // modelBuilder.Entity<DebitCard>().HasData(
           //     new DebitCard { Id = 1, Name = "Cartão Refeição", Description = "Cartão Refeição - Hexis", Balance = 0, OpenDate = new DateTime(2015, 09, 01), ClosedDate = null, User = userVasco! }
           // );

           // modelBuilder.Entity<PersonalCredit>().HasData(
           //   new PersonalCredit { Id = 1, Name = "Empréstimo João", Description = "Empréstimo João", User = userVasco!, Installment = 0, OutstandingBalance = -2750, TAN = 0, InitialDebt = 2750 },
           //   new PersonalCredit { Id = 2, Name = "Cofidis", Description = "Cofidis - consolidação", User = userVasco!, Installment = (decimal)368.35, OutstandingBalance = (decimal)-28931.33, TAN = (decimal)6.5, InitialDebt = 47250 },
           //   new PersonalCredit { Id = 3, Name = "Younited credit", Description = "Younited credit - 124.94", User = userVasco!, Installment = (decimal)124.94, OutstandingBalance = (decimal)-4826.6, TAN = (decimal)10.03, InitialDebt = 7500 },
           //   new PersonalCredit { Id = 4, Name = "Younited credit", Description = "Younited credit - 257.17", User = userVasco!, Installment = (decimal)257.17, OutstandingBalance = (decimal)-13724.17, TAN = (decimal)11.79, InitialDebt = 14000 }
           // );

           // modelBuilder.Entity<CreditCard>().HasData(
           //  new CreditCard { Id = 1, Name = "Unibanco", IBAN = "PT50 0698 0000 00010137831 39", Description = "Unibanco", User = userVasco!, Installment = 0, OutstandingBalance = 0, Percentage = (decimal)0.2, Plafon = 2000, StartDate = DateTime.Now, EndDate = null, TAN = (decimal)16.4 },
           //  new CreditCard { Id = 2, Name = "Unicre Deco", IBAN = "PT50 0698 0000 00010180875 14", Description = "Unicre Deco", User = userVasco!, Installment = 0, OutstandingBalance = 0, Percentage = 1, Plafon = 1000, StartDate = DateTime.Now, EndDate = null, TAN = (decimal)16.9 },
           //  new CreditCard { Id = 3, Name = "Bankinter Card Gold", Description = "Bankinter Card Gold", User = userVasco!, Installment = 0, OutstandingBalance = 0, Percentage = 1, Plafon = 2000, StartDate = DateTime.Now, EndDate = null },
           //  new CreditCard { Id = 4, Name = "Bankinter Card Mapfre", Description = "Bankinter Card Mapfre", User = userVasco!, Installment = 0, OutstandingBalance = 0, Percentage = (decimal)0.99, Plafon = 1000, StartDate = DateTime.Now, EndDate = null },
           //  new CreditCard { Id = 5, Name = "Wizink", Description = "Wizink", User = userVasco!, Installment = 0, OutstandingBalance = 0, Percentage = (decimal)0.05, Plafon = 6400, StartDate = DateTime.Now, EndDate = null },
           //  new CreditCard { Id = 1, Name = "Cetelem Banco CTT", Description = "Cetelem Banco CTT", User = userVasco!, Installment = 0, OutstandingBalance = -2000, Percentage = 1, Plafon = 2000, StartDate = DateTime.Now, EndDate = null },
           //  new CreditCard { Id = 1, Name = "Conta Banco CTT", Description = "Conta Banco CTT", User = userVasco!, Installment = 0, OutstandingBalance = -3450, Percentage = (decimal)0.1, Plafon = 3450, StartDate = DateTime.Now, EndDate = null }
           //);

           // modelBuilder.Entity<Earning>().HasData(
           //    new Earning { Id = 1, Name = "Vencimento", Description = "Vencimento - Hexis", User = userVasco!, OpenDate = new DateTime(2022, 09, 16), ClosedDate = null, GrossAmountWithTaxes = (decimal)1822.5, NetAmount = 850, Period = (int)Period.Monthly },
           //    new Earning { Id = 2, Name = "Cartão refeição", Description = "Cartão refeição - Hexis", User = userVasco!, OpenDate = new DateTime(2022, 09, 16), ClosedDate = null, GrossAmountWithTaxes = 174, NetAmount = 0, Period = (int)Period.Monthly },
           //    new Earning
           //    {
           //        Id = 3,
           //        Name = "OSRS",
           //        Description = "Lucros OSRS",
           //        User = userVasco!,
           //        OpenDate = new DateTime(2024, 01, 01),
           //        ClosedDate = null,
           //        GrossAmountWithTaxes = 20,
           //        Period = (int)Period.Monthly,
           //        NetAmount = 0
           //    }
           // );

           // if (!Transactions.Any())
           // {
           //     int transactionID = 0;
           //     DateTime startDate = new DateTime(2024, 01, 01);
           //     DateTime dateTime = new DateTime(2050, 12, 31);
           //     List<Transaction> oLstTransaction = new List<Transaction>();

           //     BankAccount bancoCTT = BankAccounts.Find(1)!;
           //     Earning salarioEarning = Earnings.Find(1)!;
           //     Earning cartaoRefeicaoEarning = Earnings.Find(2)!;

           //     DebitCard debitCard = DebitCards.Find(1);

           //     while (startDate < dateTime)
           //     {
           //         oLstTransaction.Add(new Transaction
           //         {
           //             Amount = salarioEarning.GrossAmountWithTaxes + salarioEarning.NetAmount,
           //             DateOfOperation = new DateTime(startDate.Year, startDate.Month, 25),
           //             Description = salarioEarning.Description,
           //             DestinationBankAccount = bancoCTT,
           //             DestinationCreditCard = null,
           //             MortgageLoan = null,
           //             PersonalCredit = null,
           //             SourceBankAccount = null,
           //             SourceCreditCard = null,
           //             User = userVasco!,
           //             TransactionFiles = null,
           //             TransactionState = (int)TransactionState.Pending,
           //             DebitCard = null
           //         });

           //         if (startDate.Month != 6)
           //         {
           //             oLstTransaction.Add(new Transaction
           //             {
           //                 Amount = cartaoRefeicaoEarning.GrossAmountWithTaxes,
           //                 DateOfOperation = new DateTime(startDate.Year, startDate.Month, 25),
           //                 Description = cartaoRefeicaoEarning.Description,
           //                 DestinationBankAccount = null,
           //                 DestinationCreditCard = null,
           //                 MortgageLoan = null,
           //                 PersonalCredit = null,
           //                 SourceBankAccount = null,
           //                 SourceCreditCard = null,
           //                 User = userVasco!,
           //                 TransactionFiles = null,
           //                 TransactionState = (int)TransactionState.Pending,
           //                 DebitCard = debitCard
           //             });
           //         }

           //         if (startDate.Month == 6 || startDate.Month == 12)
           //         {
           //             oLstTransaction.Add(new Transaction
           //             {
           //                 Amount = salarioEarning.GrossAmountWithTaxes,
           //                 DateOfOperation = startDate.Month == 6 ? new DateTime(startDate.Year, startDate.Month, 25) : new DateTime(startDate.Year, startDate.Month, 15),
           //                 Description = startDate.Month == 6 ? "Sub Férias" : "Sub. Natal",
           //                 DestinationBankAccount = bancoCTT,
           //                 DestinationCreditCard = null,
           //                 MortgageLoan = null,
           //                 PersonalCredit = null,
           //                 SourceBankAccount = null,
           //                 SourceCreditCard = null,
           //                 User = userVasco!,
           //                 TransactionFiles = null,
           //                 TransactionState = (int)TransactionState.Pending,
           //                 DebitCard = null
           //             });
           //         }


           //         startDate = startDate.AddMonths(1);
           //     }

           //     SaveChanges();
           // }


            //modelBuilder.Entity<Transaction>().HasData(
            //    new Transaction
            //    {
            //        Id = 1,
            //        Description = "Juros conta à ordem",
            //        Amount = (decimal)-37.79,
            //        User = userVasco!,
            //        DateOfOperation = new DateTime(2024, 01, 01),
            //        TransactionState = (int)TransactionState.Finished,
            //        TransactionFiles = null,
            //        DestinationBankAccount = bankBancoCTT
            //    }
            //);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<MortgageLoan> MortgageLoans { get; set; }
        public DbSet<FinanceGoal> FinanceGoals { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<TransactionFile> TransactionFiles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PersonalCredit> PersonalCredits { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Earning> Earnings { get; set; }

    }
}