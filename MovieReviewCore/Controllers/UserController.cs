using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieReviewCore.Data;
using MovieReviewCore.Models;

namespace MovieReviewCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UserController(AppDBContext context)
        {
            _context = context;
        }

        // GET: User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Index()
        {
            return _context.Movie != null ?
                        await _context.User.ToListAsync() :
                        Problem("Entity set 'AppDBContext.User'  is null.");
        }

        [HttpGet("{id}")]
        // GET: User/Details/5
        public async Task<ActionResult<User>> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Details", new { id = user.UserId }, user);
            }
            return Problem("Malformed Data Entry");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId)
            {
                return Content("Bad request");
            }

            _context.Entry(user).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Content("Sucessful Edit");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'AppDBContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return Content("Sucessful Deletion");
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}