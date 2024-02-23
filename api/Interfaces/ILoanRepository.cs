using api.Models;

namespace api.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> CreateAsync(Loan loan);
    }
}
