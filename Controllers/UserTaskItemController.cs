using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserTaskItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/usertaskitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTaskItem>>> GetUserTaskItems()
        {
            return await _context.UserTaskItems.ToListAsync();
        }

        // GET: api/usertaskitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTaskItem>> GetUserTaskItem(int id)
        {
            var userTaskItem = await _context.UserTaskItems.FindAsync(id);

            if (userTaskItem == null)
            {
                return NotFound();
            }

            return userTaskItem;
        }

        // POST: api/usertaskitem
        [HttpPost]
        public async Task<ActionResult<UserTaskItem>> PostUserTaskItem(UserTaskItem userTaskItem)
        {
            _context.UserTaskItems.Add(userTaskItem);  // Doðru DbSet ismi
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserTaskItem), new { id = userTaskItem.Id }, userTaskItem);
        }

        // PUT: api/usertaskitem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTaskItem(int id, UserTaskItem userTaskItem)
        {
            if (id != userTaskItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(userTaskItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/usertaskitem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTaskItem(int id)
        {
            var userTaskItem = await _context.UserTaskItems.FindAsync(id);
            if (userTaskItem == null)
            {
                return NotFound();
            }

            _context.UserTaskItems.Remove(userTaskItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
