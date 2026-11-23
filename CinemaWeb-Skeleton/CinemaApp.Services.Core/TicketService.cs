using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Ticket.Request;
using CinemaApp.Services.Core.Data.Ticket.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.GCommon.InputValidationConstants.Ticket;

namespace CinemaApp.Services.Core
{
    public class TicketService : ITicketService
    {
        private readonly IUserTicketRepository _userTicketRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public TicketService(IUserTicketRepository userTicketRepository, ITicketRepository ticketRepository, UserManager<IdentityUser> userManager)
        {
            _userTicketRepository = userTicketRepository;
            _ticketRepository = ticketRepository;
            _userManager = userManager;
        }

        public async Task<bool> BuyTicketsByUserIdAndProjectionIdAsync(BuyTicketsRequestModel requestData)
        {
            Ticket? dbTicket = await _ticketRepository
                .AllAsNoTracking()
                .SingleOrDefaultAsync(t => t.ProjectionId == requestData.ProjectionId);

            if (dbTicket == null)
            {
                return false;
            }

            IdentityUser? dbUser = await _userManager.FindByIdAsync(requestData.UserId);

            if (dbUser == null)
            {
                return false;
            }

            if (requestData.Quantity < MinimumPurchaseQuantity)
            {
                return false;
            }

            try
            {
                UserTicket newUserTicket = new UserTicket
                {
                    TicketId = dbTicket.Id,
                    UserId = requestData.UserId,
                    Quantity = requestData.Quantity
                };

                await _userTicketRepository.AddAsync(newUserTicket);
                await _userTicketRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<int> GetBoughtTicketsPerProjectionAsync(Guid projectionId)
        {
            Ticket? dbTicket = await _ticketRepository
                .AllAsNoTracking()
                .Include(t => t.TicketUsers)
                .SingleOrDefaultAsync(t => t.ProjectionId == projectionId);

            if (dbTicket == null)
            {
                return 0;
            }

            int ticketsBought = dbTicket.TicketUsers
                .Sum(ut => ut.Quantity);

            return ticketsBought;
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
