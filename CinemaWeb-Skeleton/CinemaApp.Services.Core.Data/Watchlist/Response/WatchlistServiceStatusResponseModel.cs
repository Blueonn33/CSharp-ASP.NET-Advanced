using CinemaApp.Services.Core.Data.Watchlist.Enums;

namespace CinemaApp.Services.Core.Data.Watchlist.Response
{
    public class WatchlistServiceStatusResponseModel
    {
        public WatchlistServiceResponseStatus Status
        {
            get; set;
        }

        public ICollection<string?> ErrorMessages { get; set; } = new List<string?>();
    }
}
