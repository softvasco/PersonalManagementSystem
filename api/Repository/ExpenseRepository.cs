using api.Data;
using api.Dtos.Earnings;
using api.Enum;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDBContext _context;

        public ExpenseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Expense> CreateAsync(Expense expense)
        {
            var subCategory = await _context
                .SubCategories
                .AsNoTracking()
                .Include(x => x.Category.User)
                .FirstOrDefaultAsync(x =>x.Id == expense.SubCategoryId);

            if (subCategory is null)
            {
                throw new NotFoundException("sub category does not exist!");
            }

            var earningExists = await _context
                .Expenses
                .AsNoTracking()
                .AnyAsync(x => x.Code == expense.Code
                    && x.SubCategoryId == expense.SubCategoryId
                    && x.IsActive);

            if (earningExists)
            {
                throw new Exception("Expense already exists!");
            }

            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();

            DateTime indexData = Utils.CalculateNextPaymentDate(expense.StartDate, expense.PayDay);

            while (indexData < expense.EndDate)
            {
                if (expense.Months.Contains(indexData.Month))
                {
                    await _context.Transactions.AddAsync(new Transaction
                    {
                        OperationDate = indexData,
                        Description = expense.Description,
                        State = (int)TransactionState.Pending,
                        ExpenseId = expense.Id,
                        SourceAccountOrCardCode = expense.SourceAccountOrCardCode,
                        DestinationAccountOrCardCode = expense.DestinationAccountOrCardCode,
                        Amount = expense.Amount,
                        Attachment = expense.FileContent,
                        UserId = subCategory.Category.UserId
                    });
                }

                indexData = indexData.AddMonths(1);
            }

            await _context.SaveChangesAsync();

            return expense;
        }


        public Task<Expense> UpdateAsync(int id, Expense expense)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}