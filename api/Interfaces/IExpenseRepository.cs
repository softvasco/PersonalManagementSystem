using Shared.Dtos.Expenses;
using api.Models;

namespace api.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<ExpenseDto>> GetAsync();
        Task<Expense> CreateAsync(Expense expense);
        Task<Expense> UpdateAsync(int id, Expense expense);
        Task<Expense> DeleteAsync(int id);
    }
}
