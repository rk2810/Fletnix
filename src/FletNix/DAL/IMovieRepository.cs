using System;
using System.Linq;
using System.Threading.Tasks;
using FletNix.Models;

namespace FletNix.DAL
{
    public interface IMovieRepository : IDisposable
    {
        IQueryable<MovieListItem> GetMovieList(DateTime? minimumDate = null);

        Task<Movie> GetMovie(int id);
    }
}
