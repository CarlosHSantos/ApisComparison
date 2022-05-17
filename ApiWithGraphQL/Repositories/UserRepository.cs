using SharedClasses.Context;
using SharedClasses.Models;

namespace ApiComGraphQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DefaultDbContext _context;

        public UserRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task<UserPayload> AddUser(User user)
        {
            if (_context.Users.Any(e => e.Email == user.Email))
            {
                return new UserPayload(new User(), "Existing email in our database");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserPayload(user);
        }
    }
}
