using api.Models;

namespace api.Interfaces
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateAsync(Expense expense);
        Task<Expense> UpdateAsync(int id, Expense expense);
        Task<Expense> DeleteAsync(int id);
    }
}
