using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedClasses.Context;
using SharedClasses.Models;

namespace ApiSemGraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public UserController(DefaultDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            if (UserExists(User.Email))
            {
                return BadRequest("E-mail existente em nosso banco de dados");
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        private bool UserExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
    }
}