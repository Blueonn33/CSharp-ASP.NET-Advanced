using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class CinemaRepository : BaseSoftDeletableRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
