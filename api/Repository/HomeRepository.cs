using api.Data;
using api.Dtos.Home;
using api.Interfaces;
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
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<HomeDto> GetAsync(int UserId, int year)
        {
            _context.Transactions
                .Include(sub => sub.SubCategory)
                .Where(x => x.UserId == UserId
                    && x.IsActive
                    && x.OperationDate.Year == year);

            HomeDto homeDto = new HomeDto();
            homeDto.HomeCategoryDto.Name = "Janeiro";
            homeDto.HomeCategoryDto.JanuaryPrev = 10;
            homeDto.HomeCategoryDto.JanuaryPrev = 10;

            return new HomeDto();
        }
    }
}