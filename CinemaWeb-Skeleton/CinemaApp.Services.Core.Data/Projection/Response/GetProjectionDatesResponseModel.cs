namespace CinemaApp.Services.Core.Data.Projection.Response
{
    public class GetProjectionDatesResponseModel
    {
        public Guid Id
        {
            get; set;
        }

        public Guid MovieId
        {
            get; set;
        }

        public Guid CinemaId
        {
            get; set;
        }

        public DateTime Showtime
        {
            get; set;
        }
    }
}
