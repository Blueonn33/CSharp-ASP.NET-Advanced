using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository
{
    public class UserTicketRepository : BaseRepository<UserTicket>, IUserTicketRepository
    {
        public UserTicketRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
