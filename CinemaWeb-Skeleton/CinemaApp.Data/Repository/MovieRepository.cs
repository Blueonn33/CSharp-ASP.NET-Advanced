using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class MovieRepository : BaseSoftDeletableRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Movie?> FindByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
