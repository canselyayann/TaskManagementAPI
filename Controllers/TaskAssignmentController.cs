using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskAssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/taskassignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskAssignment>>> GetTaskAssignments()
        {
            return await _context.TaskAssignments.Include(t => t.Task).Include(u => u.User).ToListAsync();
        }

        // POST: api/taskassignment
        [HttpPost]
        public async Task<ActionResult<TaskAssignment>> PostTaskAssignment(TaskAssignment taskAssignment)
        {
            _context.TaskAssignments.Add(taskAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskAssignments), new { id = taskAssignment.Id }, taskAssignment);
        }
    }
}
