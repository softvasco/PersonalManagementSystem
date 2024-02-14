using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class MortgageLoanRepository : IMortgageLoanRepository
    {
        private readonly ApplicationDBContext _context;

        public MortgageLoanRepository(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}