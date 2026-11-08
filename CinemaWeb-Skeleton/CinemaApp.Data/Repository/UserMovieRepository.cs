using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class UserMovieRepository : BaseRepository<UserMovie>, IUserMovieRepository
    {
        public UserMovieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
