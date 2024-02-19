using api.Data;
using api.Interfaces;
using api.Models;

namespace api.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public SubCategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

    }
}