using System;
using System.Linq;
using System.Threading.Tasks;
using FletNix.DAL;
using FletNix.Helpers.Paging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FletNix.Models;
using Microsoft.AspNetCore.Authorization;

namespace FletNix.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var movies = this._movieRepository.GetMovieList().OrderByDescending(m => m.AverageRating);

            int pageSize = 10;

            return View(await PaginatedList<MovieListItem>.CreateAsync(movies.AsNoTracking(), page ?? 1, pageSize));
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.GetMovie((int) id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
