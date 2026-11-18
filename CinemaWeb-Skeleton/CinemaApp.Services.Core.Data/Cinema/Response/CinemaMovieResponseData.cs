namespace CinemaApp.Services.Core.Data.Cinema.Response
{
    public class CinemaMovieResponseData
    {
        public Guid Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string Director { get; set; } = null!;

        public string? ImageUrl
        {
            get; set;
        }
    }
}
