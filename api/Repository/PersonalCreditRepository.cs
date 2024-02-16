using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class PersonalCreditRepository : IPersonalCreditRepository
    {
        private readonly ApplicationDBContext _context;

        public PersonalCreditRepository(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}