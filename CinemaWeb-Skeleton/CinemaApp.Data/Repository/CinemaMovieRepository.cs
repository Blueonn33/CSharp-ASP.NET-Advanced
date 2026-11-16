using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class CinemaMovieRepository : BaseSoftDeletableRepository<CinemaMovie>, ICinemaMovieRepository
    {
        public CinemaMovieRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
