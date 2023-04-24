using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieReviewCore.Data;
using MovieReviewCore.Models;

namespace MovieReviewCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly AppDBContext _context;

        public MoviesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Index()
        {
              return _context.Movie != null ? 
                          await _context.Movie.ToListAsync() :
                          Problem("Entity set 'AppDBContext.Movie'  is null.");
        }

        [HttpGet("{id}")]
        // GET: Movies/Details/5
        public async Task<ActionResult<Movie>> Details(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Details", new { id = movie.MovieId }, movie);
            }
            return Problem("Malformed Data Entry");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return Content("Bad request");
            }

            _context.Entry(movie).State = EntityState.Modified;

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            if (_context.Movie == null)
            {
                return Problem("Entity set 'AppDBContext.Movie'  is null.");
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return Content("Sucessful Deletion");
        }

        private bool MovieExists(int id)
        {
          return (_context.Movie?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}
