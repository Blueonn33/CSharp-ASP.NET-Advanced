namespace CinemaApp.Services.Core.Data.Watchlist.Enums
{
    public enum WatchlistServiceResponseStatus
    {
        Success = 0,
        InvalidReference = 1,
        DuplicatedEntry = 2,
        EntityNotFound = 3,
        GeneralError = 4
    }
}
