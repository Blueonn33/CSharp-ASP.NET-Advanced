namespace CinemaApp.Services.Core.Data.Ticket.Request
{
    public class BuyTicketsRequestModel
    {
        public Guid ProjectionId
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        }

        public int Quantity
        {
            get; set;
        }
    }
}
