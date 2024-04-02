using api.Data;
using api.Dtos.Home;
using api.Enum;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ITransactionRepository _transactionRepository;

        public HomeRepository(ApplicationDBContext context,
            ITransactionRepository transactionRepository)
        {
            _context = context;
            _transactionRepository = transactionRepository;
        }

        /// <summary>
        /// Gets the home data for a specific user and year.
        /// </summary>
        /// <param name="UserId">The user ID.</param>
        /// <param name="year">The year.</param>
        /// <returns>The home data.</returns>
        public async Task<HomeDto> GetAsync(int UserId, int year)
        {
            HomeDto homeDto = new HomeDto();
            
            var homeCategories = await CalculateCategories(UserId, year);
            homeDto.HomeCategories = homeCategories;

            var prevOfFinanceGoal = await CalculatePrevFinanceGoal(UserId, year);
            homeDto.HomeFinanceGoal = prevOfFinanceGoal;

            return homeDto;
        }

        private async Task<List<HomeCategoryDto>> CalculateCategories(int UserId, int year)
        {
            List<HomeCategoryDto> homeCategories = new();

            var transactions = await _context.Transactions
                                            .Include(sub => sub.SubCategory)
                                            .Where(x => x.UserId == UserId
                                                && x.IsActive
                                                && x.OperationDate.Year == year)
                                            .ToListAsync();

            var categories = _context.Categories.Where(x => x.UserId == UserId && x.IsActive).ToList();

            foreach (var category in categories)
            {
                HomeCategoryDto homeCategoryDto = new();
                homeCategoryDto.CategoryName = category.Description;

                for (int month = 1; month <= 12; month++)
                {
                    decimal realAmount = GetRealAmountForMonth(transactions, category.Id, UserId, month);
                    SetRealAmountForMonth(homeCategoryDto, month, realAmount);
                }

                homeCategories.Add(homeCategoryDto);
            }

            return homeCategories;
        }

        private decimal GetRealAmountForMonth(List<Transaction> transactions, int categoryId, int userId, int month)
        {
            return transactions
                .Where(x => (x.SubCategory is not null && x.SubCategory.CategoryId == categoryId)
                    && x.UserId == userId
                    && x.OperationDate.Month == month 
                    && x.State == (int)TransactionState.Finished)
                .Sum(x => x.Amount);
        }

        private void SetRealAmountForMonth(HomeCategoryDto homeCategoryDto, int month, decimal amount)
        {
            switch (month)
            {
                case 1:
                    homeCategoryDto.JanuaryExpenses = amount;
                    break;
                case 2:
                    homeCategoryDto.FebruaryExpenses = amount;
                    break;
                case 3:
                    homeCategoryDto.MarchExpenses = amount;
                    break;
                case 4:
                    homeCategoryDto.AprilExpenses = amount;
                    break;
                case 5:
                    homeCategoryDto.MayExpenses = amount;
                    break;
                case 6:
                    homeCategoryDto.JuneExpenses = amount;
                    break;
                case 7:
                    homeCategoryDto.JulyExpenses = amount;
                    break;
                case 8:
                    homeCategoryDto.AugustExpenses = amount;
                    break;
                case 9:
                    homeCategoryDto.SeptemberExpenses = amount;
                    break;
                case 10:
                    homeCategoryDto.OctoberExpenses = amount;
                    break;
                case 11:
                    homeCategoryDto.NovemberExpenses = amount;
                    break;
                case 12:
                    homeCategoryDto.DecemberExpenses = amount;
                    break;
            }
        }

        private async Task<HomeFinanceGoal> CalculatePrevFinanceGoal(int userId, int year)
        {
            HomeFinanceGoal homeFinanceGoal = new HomeFinanceGoal();

            var financeGoal = _context.FinanceGoals.First(x => x.UserId == userId);

            homeFinanceGoal.StartGoalDate = financeGoal.StartGoalDate;
            homeFinanceGoal.EndGoalDate = financeGoal.EndGoalDate;
            homeFinanceGoal.OutstandingAmount = financeGoal.OutstandingAmount;
            homeFinanceGoal.DebtAmount = await CalculateDebtAmount(userId, year);
            homeFinanceGoal.Goal = financeGoal.Goal;
            homeFinanceGoal.Diff = financeGoal.Goal - homeFinanceGoal.DebtAmount;

            return homeFinanceGoal;
        }

        private async Task<decimal> CalculateDebtAmount(int userId, int year)
        {
            var transactions = _context
                                    .Transactions
                                    .Where(x => x.UserId == userId
                                        && x.OperationDate.Year == year
                                        && x.State == (int)TransactionState.Pending)
                                    .OrderBy(x => x.OperationDate)
                                    .ToList();

            BankAccount bankAccount = await _context.BankAccounts.FirstAsync(x => x.Code == "BancoCTT");
            List<Credit> credits = await _context.Credits.Where(x => x.UserId == 1 && x.IsActive).ToListAsync();
            List<CreditCard> creditCards = await _context.CreditCards.Where(x => x.UserId == 1 && x.IsActive).ToListAsync();

            foreach (var transaction in transactions)
            {
                //Debit
                if (!string.IsNullOrEmpty(transaction.SourceAccountOrCardCode) && transaction.SourceAccountOrCardCode == bankAccount.Code)
                {
                    bankAccount.Balance -= transaction.Amount;
                }
                if (!string.IsNullOrEmpty(transaction.SourceAccountOrCardCode) && creditCards.Select(x => x.Code).Contains(transaction.SourceAccountOrCardCode))
                {
                    creditCards.First(x => x.Code == transaction.SourceAccountOrCardCode).Balance -= transaction.Amount;
                }

                //Credit
                if (!string.IsNullOrEmpty(transaction.DestinationAccountOrCardCode) && transaction.DestinationAccountOrCardCode == bankAccount.Code)
                {
                    bankAccount.Balance += transaction.Amount;
                }
                if (!string.IsNullOrEmpty(transaction.DestinationAccountOrCardCode) && credits.Select(x => x.Code).Contains(transaction.DestinationAccountOrCardCode))
                {
                    if (transaction.Description.Contains("Ana - Cofidis"))
                    {
                        credits.First(x => x.Code == transaction.DestinationAccountOrCardCode).DebtCapital -= transaction.Amount;
                    }
                    else
                    {
                        credits.First(x => x.Code == transaction.DestinationAccountOrCardCode).DebtCapital = credits.First(x => x.Code == transaction.DestinationAccountOrCardCode).DebtCapital + (credits.First(x => x.Code == transaction.DestinationAccountOrCardCode).DebtCapital * (credits.First(x => x.Code == transaction.DestinationAccountOrCardCode).TAN / 100 / 12)) - credits.First(x => x.Code == transaction.DestinationAccountOrCardCode).Installment;
                    }
                }
                if (!string.IsNullOrEmpty(transaction.DestinationAccountOrCardCode) && creditCards.Select(x => x.Code).Contains(transaction.DestinationAccountOrCardCode))
                {
                    creditCards.First(x => x.Code == transaction.DestinationAccountOrCardCode).Balance += transaction.Amount;
                }
            }

            decimal banks = bankAccount.Balance < 0 ? bankAccount.Balance * -1 : -1 * bankAccount.Balance;
            decimal creditDebpts = credits.Sum(x => x.DebtCapital);
            decimal creditCardsDEbpts = creditCards.Sum(x => x.Plafon - x.Balance);

            return decimal.Round(banks + creditDebpts + creditCardsDEbpts, 2);
        }

    }
}