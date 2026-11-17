using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
