using api.Data;
using api.Interfaces;
using api.Models;

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
            if (_context.Users.Any(x => x.Username == user.Username || x.Email == x.Email))
                throw new Exception("User already exists!");

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}