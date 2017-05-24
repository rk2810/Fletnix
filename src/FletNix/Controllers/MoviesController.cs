using System;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Helpers.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FletNix.Models;
using Microsoft.AspNetCore.Authorization;

namespace FletNix.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FLETNIXContext _context;

        public MoviesController(FLETNIXContext context)
        {
            _context = context;    
        }

        [Authorize]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var movies = _context.Movie.GroupJoin(_context.CustomerFeedback, m => m.MovieId, cf => cf.MovieId, (m, cf) => new
            {
                MovieId = m.MovieId,
                Title = m.Title,
                AverageRating = cf.DefaultIfEmpty(new CustomerFeedback
                {
                    Rating = 0
                }).Average(f => f.Rating)
            });

//            var movies = from s in _context.Movie
//                select s;

            int pageSize = 10;

            return View(await PaginatedList<Movie>.CreateAsync(movies.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.MovieDirector)
                .ThenInclude(m => m.Person)
                .Include(m => m.MovieCast)
                .ThenInclude(m => m.Person)
                .Include(m => m.MovieGenre)
                .SingleOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
