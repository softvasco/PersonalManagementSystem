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

        public HomeRepository(ApplicationDBContext context)
        {
            _context = context;
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

                homeDto.HomeCategories.Add(homeCategoryDto);
            }

            return homeDto;
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

    }
}