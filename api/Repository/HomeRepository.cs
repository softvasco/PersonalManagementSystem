using api.Data;
using Shared.Dtos.Home;
using Shared.Enum;
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
        /// <param name="userId">The user ID.</param>
        /// <param name="year">The year.</param>
        /// <returns>The home data.</returns>
        public async Task<HomeDto> GetAsync(int userId, int year)
        {
            HomeDto homeDto = new HomeDto();
            
            var transactions = await _context.Transactions
                                   .Include(sub => sub.SubCategory)
                                   .Where(x => x.UserId == userId
                                       && x.IsActive
                                       && x.OperationDate.Year == year)
                                   .ToListAsync();

            var homeCategories = await CalculateCategories(transactions, userId);
            homeDto.HomeCategories = homeCategories;
            
            var homeSubCategories = await CalculateSubCategories(transactions, userId);
            homeDto.HomeSubCategories = homeSubCategories;

            var prevOfFinanceGoal = await CalculatePrevFinanceGoal(userId, year);
            homeDto.HomeFinanceGoal = prevOfFinanceGoal;

            return homeDto;
        }

        private async Task<List<HomeCategoryDto>> CalculateCategories(List<Transaction> transactions,
            int userId)
        {
            List<HomeCategoryDto> homeCategories = new();

            var categories = await _context
                .Categories
                .Where(x => x.UserId == userId && x.IsActive)
                .ToListAsync();

            foreach (var category in categories)
            {
                HomeCategoryDto homeCategoryDto = new();
                homeCategoryDto.CategoryName = category.Description;

                for (int month = 1; month <= 12; month++)
                {
                    decimal realAmount = GetRealAmountForMonth(transactions, category.Id, userId, month);
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
                    && x.OperationDate.Month == month )
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

            List<BankAccount> bankAccounts = await _context.BankAccounts.Where(x => x.Code != "BankinterCH").ToListAsync();
            List<Credit> credits = await _context.Credits.Where(x => x.UserId == 1 && x.IsActive).ToListAsync();
            List<CreditCard> creditCards = await _context.CreditCards.Where(x => x.UserId == 1 && x.IsActive).ToListAsync();

            foreach (var transaction in transactions)
            {
                //Debit
                if (!string.IsNullOrEmpty(transaction.SourceAccountOrCardCode) && bankAccounts.Select(x => x.Code).Contains(transaction.SourceAccountOrCardCode))
                {
                    bankAccounts.FirstOrDefault(x => x.Code == transaction.SourceAccountOrCardCode)!.Balance -= transaction.Amount;
                }
                if (!string.IsNullOrEmpty(transaction.SourceAccountOrCardCode) && creditCards.Select(x => x.Code).Contains(transaction.SourceAccountOrCardCode))
                {
                    creditCards.First(x => x.Code == transaction.SourceAccountOrCardCode).Balance -= transaction.Amount;
                }

                //Credit
                if (!string.IsNullOrEmpty(transaction.DestinationAccountOrCardCode) && bankAccounts.Select(x => x.Code).Contains(transaction.DestinationAccountOrCardCode))
                {
                    bankAccounts.FirstOrDefault(x => x.Code == transaction.DestinationAccountOrCardCode)!.Balance += transaction.Amount;
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

            decimal banks = bankAccounts.Sum(x => x.Balance) < 0 ? bankAccounts.Sum(x => x.Balance) * -1 : -1 * bankAccounts.Sum(x => x.Balance);
            decimal creditDebpts = credits.Sum(x => x.DebtCapital);
            decimal creditCardsDEbpts = creditCards.Sum(x => x.Plafon - x.Balance);

            return decimal.Round(banks + creditDebpts + creditCardsDEbpts, 2);
        }

        private async Task<List<HomeSubCategoryDto>> CalculateSubCategories(List<Transaction> transactions,
            int userId)
        {
            List<HomeSubCategoryDto> listHomeSubCategoryDto = new();

            var subCategories = await _context
                .SubCategories
                .OrderBy(x => x.CategoryId)
                .ThenBy(x => x.Description)
                .Include(x => x.Category)
                .Where(x => x.IsVisibleInHomePage)
                .ToListAsync();

            foreach (var subCategory in subCategories)
            {
                HomeSubCategoryDto homeSubCategoryDto = new();
                homeSubCategoryDto.SubCategoryName = subCategory.Description;
                homeSubCategoryDto.CategoryName = subCategory.Category.Description;
                for (int month = 1; month <= 12; month++)
                {
                    decimal realAmount = GetRealAmountForMonthBySubCategory(transactions, subCategory.Id, userId, month);
                    SetRealAmountForMonthBySubCategory(homeSubCategoryDto, month, realAmount, subCategory.MonthlyPlafond);
                }

                if (homeSubCategoryDto.JanuaryExpenses + homeSubCategoryDto.FebruaryExpenses + homeSubCategoryDto.MarchExpenses +
                    homeSubCategoryDto.AprilExpenses + homeSubCategoryDto.MayExpenses + homeSubCategoryDto.JuneExpenses +
                    homeSubCategoryDto.JulyExpenses + homeSubCategoryDto.AugustExpenses + homeSubCategoryDto.SeptemberExpenses +
                    homeSubCategoryDto.OctoberExpenses + homeSubCategoryDto.NovemberExpenses + homeSubCategoryDto.DecemberExpenses > 0)
                    listHomeSubCategoryDto.Add(homeSubCategoryDto);
            }

            return listHomeSubCategoryDto;
        }

        private decimal GetRealAmountForMonthBySubCategory(List<Transaction> transactions,
            int subCategoryId, int userId, int month)
        {
            return transactions
                .Where(x => (x.SubCategoryId == subCategoryId)
                    && x.UserId == userId
                    && x.OperationDate.Month == month)
                .Sum(x => x.Amount);
        }

        private void SetRealAmountForMonthBySubCategory(HomeSubCategoryDto homeSubCategoryDto, 
            int month, decimal amount, decimal? plafon)
        {
            switch (month)
            {
                case 1:
                    homeSubCategoryDto.JanuaryExpenses = amount;
                    homeSubCategoryDto.JanuaryExpensesPlafon = plafon ?? 0;
                    break;
                case 2:
                    homeSubCategoryDto.FebruaryExpenses = amount;
                    homeSubCategoryDto.FebruaryExpensesPlafon = plafon ?? 0;
                    break;
                case 3:
                    homeSubCategoryDto.MarchExpenses = amount;
                    homeSubCategoryDto.MarchExpensesPlafon = plafon ?? 0;
                    break;
                case 4:
                    homeSubCategoryDto.AprilExpenses = amount;
                    homeSubCategoryDto.AprilExpensesPlafon = plafon ?? 0;
                    break;
                case 5:
                    homeSubCategoryDto.MayExpenses = amount;
                    homeSubCategoryDto.MayExpensesPlafon = plafon ?? 0;
                    break;
                case 6:
                    homeSubCategoryDto.JuneExpenses = amount;
                    homeSubCategoryDto.JuneExpensesPlafon = plafon ?? 0;
                    break;
                case 7:
                    homeSubCategoryDto.JulyExpenses = amount;
                    homeSubCategoryDto.JulyExpensesPlafon = plafon ?? 0;
                    break;
                case 8:
                    homeSubCategoryDto.AugustExpenses = amount;
                    homeSubCategoryDto.AugustExpensesPlafon = plafon ?? 0;
                    break;
                case 9:
                    homeSubCategoryDto.SeptemberExpenses = amount;
                    homeSubCategoryDto.SeptemberExpensesPlafon = plafon ?? 0;
                    break;
                case 10:
                    homeSubCategoryDto.OctoberExpenses = amount;
                    homeSubCategoryDto.OctoberExpensesPlafon = plafon ?? 0;
                    break;
                case 11:
                    homeSubCategoryDto.NovemberExpenses = amount;
                    homeSubCategoryDto.NovemberExpensesPlafon = plafon ?? 0;
                    break;
                case 12:
                    homeSubCategoryDto.DecemberExpenses = amount;
                    homeSubCategoryDto.DecemberExpensesPlafon = plafon ?? 0;
                    break;
            }
        }

    }
}