namespace CinemaApp.Services.Core.Data.Watchlist.Response
{
    public class UserFullWatchlistResponseData
    {
        public IEnumerable<WatchlistMovieDataModel> Movies { get; set; } = new List<WatchlistMovieDataModel>();
    }
}
