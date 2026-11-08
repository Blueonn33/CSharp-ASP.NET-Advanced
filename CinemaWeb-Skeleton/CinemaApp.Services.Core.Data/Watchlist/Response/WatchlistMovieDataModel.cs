namespace CinemaApp.Services.Core.Data.Watchlist.Response
{
    public class WatchlistMovieDataModel
    {
        public Guid Id
        {
            get; set;
        }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate
        {
            get; set;
        }

        public string? ImageUrl
        {
            get; set;
        }
    }
}
