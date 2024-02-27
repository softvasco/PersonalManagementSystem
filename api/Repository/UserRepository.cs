using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                if (_context
                    .Users
                    .AsNoTracking()
                    .Any(x => (x.Username == user.Username || x.Email == user.Username) && x.IsActive))
                {
                    throw new Exception("User already exists!");
                }

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}