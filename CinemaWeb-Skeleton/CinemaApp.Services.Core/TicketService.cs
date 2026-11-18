using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Ticket.Response;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core
{
    public class TicketService : ITicketService
    {
        private readonly IUserTicketRepository _userTicketRepository;

        public TicketService(IUserTicketRepository userTicketRepository)
        {
            _userTicketRepository = userTicketRepository;
        }

        public async Task<IEnumerable<GetUserAllTicketsResponseModel>> GetUserAllTicketsByUserIdAsync(string userId)
        {
            IEnumerable<GetUserAllTicketsResponseModel> responseData = await _userTicketRepository
                .AllAsNoTracking()
                .Select(ut => new GetUserAllTicketsResponseModel()
                {
                    CinemaName = ut.Ticket.Projection.Cinema.Name,
                    MovieTitle = ut.Ticket.Projection.Movie.Title,
                    MovieImageUrl = ut.Ticket.Projection.Movie.ImageUrl,
                    Price = ut.Ticket.Price,
                    Quantity = ut.Quantity
                })
                .OrderBy(t => t.MovieTitle)
                .ThenByDescending(t => t.Quantity)
                .ToArrayAsync();

            return responseData;
        }
    }
}
