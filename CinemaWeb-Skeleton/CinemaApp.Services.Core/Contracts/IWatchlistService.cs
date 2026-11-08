using CinemaApp.Services.Core.Data.Watchlist.Response;

namespace CinemaApp.Services.Core.Contracts
{
    public interface IWatchlistService
    {
        Task<UserFullWatchlistResponseData> GetUserFullWatchlistDataAsync(string userId);

        Task<bool> IsMovieInUserWatchlistAsync(string userId, Guid movieId);

        Task<WatchlistServiceStatusResponseModel> AddMovieToWatchlistAsync(string userId, Guid movieId);

        Task<WatchlistServiceStatusResponseModel> RemoveMovieFromWatchlistAsync(string userId, Guid movieId);
    }
}
