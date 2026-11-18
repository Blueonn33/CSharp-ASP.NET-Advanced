using CinemaApp.Services.Core.Data.Ticket.Response;

namespace CinemaApp.Services.Core.Contracts
{
    public interface ITicketService
    {
        Task<IEnumerable<GetUserAllTicketsResponseModel>> GetUserAllTicketsByUserIdAsync(string userId);
    }
}
