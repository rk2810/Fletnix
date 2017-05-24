using System;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;
using Microsoft.EntityFrameworkCore;

namespace FletNix.DAL
{
    public class MovieRepository : IMovieRepository, IDisposable
    {
        private bool _disposed = false;
        private FLETNIXContext _context;

        public MovieRepository(FLETNIXContext context)
        {
            this._context = context;
        }

        public IQueryable<MovieListItem> GetMovieList(DateTime? minimumDate = null)
        {
            if (!minimumDate.HasValue)
            {
                minimumDate = DateTime.MinValue;
            }

            var movies = from p in _context.Movie
                join c in _context.CustomerFeedback on p.MovieId equals c.MovieId into customerFeedbacks
                from feedback in customerFeedbacks.DefaultIfEmpty(new CustomerFeedback { Rating = 0, FeedbackDate = DateTime.Now })
                where feedback.FeedbackDate > minimumDate
                group feedback by new { p.Title, p.MovieId, p.Description, p.Duration, p.PublicationYear, p.Price } into grouped
                select new MovieListItem
                {
                    MovieId = grouped.Key.MovieId,
                    Title = grouped.Key.Title,
                    Description = grouped.Key.Description,
                    Duration = grouped.Key.Duration,
                    PublicationYear = grouped.Key.PublicationYear,
                    Price = grouped.Key.Price,
                    AverageRating = grouped.Average(f => f.Rating)
                };

            return movies;
        }

        public Task<Movie> GetMovie(int id)
        {
            return _context.Movie
                .Include(m => m.MovieDirector)
                .ThenInclude(m => m.Person)
                .Include(m => m.MovieCast)
                .ThenInclude(m => m.Person)
                .Include(m => m.MovieGenre)
                .SingleOrDefaultAsync(m => m.MovieId == id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
