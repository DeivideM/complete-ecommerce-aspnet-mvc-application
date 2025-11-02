using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        protected readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await _context.Movies
                .Include(n => n.Cinema)
                .Include(n => n.Producer)
                .Include(n => n.Actors_Movies).ThenInclude(n => n.Actor)
                .OrderBy(n => n.Name)
                .ToListAsync();
            return movies;
        }
    }
}