namespace CinemaApp.Services.Core.Data.Ticket.Response
{
    public class GetUserAllTicketsResponseModel
    {
        public string MovieTitle { get; set; } = null!;

        public string? MovieImageUrl
        {
            get; set;
        }

        public string CinemaName { get; set; } = null!;

        public decimal Price
        {
            get; set;
        }

        public int Quantity
        {
            get; set;
        }
    }
}
