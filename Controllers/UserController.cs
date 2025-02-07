using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;


namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly YourService _yourService;

        // Constructor injection for both DbContext and YourService
        public UserController(ApplicationDbContext context, YourService yourService)
        {
            _context = context;
            _yourService = yourService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/user/login
        [HttpGet("login")]
        public ActionResult<LoginModel> GetLogin(int userId)
        {
            var login = _yourService.GetLoginByUserId(userId);

            if (login == null)
            {
                return NotFound("Login information not found for this user.");
            }

            return Ok(login);
        }

        [Authorize(Roles = "Admin")]  // Sadece Admin rolüne sahip kullanýcýlar eriþebilir
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"User with id {id} not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}

