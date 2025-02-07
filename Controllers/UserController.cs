using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);

        }
        private readonly YourService _yourService;

        public UserController(YourService yourService)
        {
            _yourService = yourService;
        }

        [HttpGet]
        public ActionResult<LoginModel> GetLogin(int userId)
        {
            var login = _yourService.GetLoginByUserId(userId);

            if (login == null)
            {
                return NotFound("Login information not found for this user.");
            }

            return Ok(login);
        }
    }
}
