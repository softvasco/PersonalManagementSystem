using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class WeightRepository : IWeightRepository
    {
        private readonly ApplicationDBContext _context;

        public WeightRepository(ApplicationDBContext context)
        {
            _context = context;
        }

       

    }
}