using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts.Common;

namespace CinemaApp.Data.Repository.Contracts
{
    public interface IMovieRepository : ISoftDeletableRepository<Movie>
    {
        Task<Movie?> FindByIdAsync(Guid id);
    }
}
