using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Watchlist.Enums;
using CinemaApp.Services.Core.Data.Watchlist.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core
{
    public class WatchlistService : IWatchlistService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public WatchlistService(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<UserFullWatchlistResponseData> GetUserFullWatchlistDataAsync(string userId)
        {
            IEnumerable<WatchlistMovieDataModel> userWatchlist = await _context.UsersMovies
                .Where(um => um.UserId.ToLower() == userId.ToLower())
                .Select(um => um.Movie)
                .Select(m => new WatchlistMovieDataModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate,
                    ImageUrl = m.ImageUrl
                })
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Genre)
                .ToArrayAsync();

            UserFullWatchlistResponseData userFullWatchlistResponseData = new UserFullWatchlistResponseData()
            {
                Movies = userWatchlist
            };

            return userFullWatchlistResponseData;
        }

        public async Task<bool> IsMovieInUserWatchlistAsync(string userId, Guid movieId)
        {
            bool isMovieInWatchlistResponse = await _context.UsersMovies
                .AnyAsync(um => um.UserId.ToLower() == userId.ToLower() && um.MovieId == movieId);

            return isMovieInWatchlistResponse;
        }

        public async Task<WatchlistServiceStatusResponseModel> AddMovieToWatchlistAsync(string userId, Guid movieId)
        {
            WatchlistServiceStatusResponseModel responseData = new WatchlistServiceStatusResponseModel()
            {
                Status = WatchlistServiceResponseStatus.GeneralError,
                ErrorMessages = new List<string?>()
            };

            IdentityUser? user = await _userManager.FindByIdAsync(userId);
            bool movieExists = await _context.Movies
                .AnyAsync(m => m.Id == movieId);

            if (!movieExists)
            {
                responseData.Status = WatchlistServiceResponseStatus.InvalidReference;
                responseData.ErrorMessages.Add("Reference movie does not exist");
            }

            if (user == null)
            {
                responseData.Status = WatchlistServiceResponseStatus.InvalidReference;
                responseData.ErrorMessages.Add("Reference user does not exist");
            }

            bool watchlistEntryExists = await _context.UsersMovies
                .AnyAsync(um => um.UserId.ToLower() == userId.ToLower() && um.MovieId == movieId);

            if (!watchlistEntryExists)
            {
                responseData.Status = WatchlistServiceResponseStatus.DuplicatedEntry;
            }
            else
            {
                try
                {
                    UserMovie userMovie = new UserMovie()
                    {
                        UserId = userId,
                        MovieId = movieId
                    };

                    await _context.UsersMovies.AddAsync(userMovie);
                    await _context.SaveChangesAsync();

                    responseData.Status = WatchlistServiceResponseStatus.Success;
                }
                catch (Exception e)
                {
                    // TODO: Log the exception details for further analysis and debugging
                    responseData.Status = WatchlistServiceResponseStatus.GeneralError;
                    responseData.ErrorMessages = new List<string?>() { e.Message };
                }
            }

            return responseData;
        }

        public async Task<WatchlistServiceStatusResponseModel> RemoveMovieFromWatchlistAsync(string userId, Guid movieId)
        {
            WatchlistServiceStatusResponseModel responseData = new WatchlistServiceStatusResponseModel()
            {
                Status = WatchlistServiceResponseStatus.GeneralError,
                ErrorMessages = new List<string?>()
            };

            IdentityUser? dbUser = await _userManager.FindByIdAsync(userId);
            bool movieExists = await _context.Movies
                .AnyAsync(m => m.Id == movieId);

            if (!movieExists)
            {
                responseData.Status = WatchlistServiceResponseStatus.InvalidReference;
                responseData.ErrorMessages.Add("Referenced movie does not exist");
            }

            if (dbUser == null)
            {
                responseData.Status = WatchlistServiceResponseStatus.InvalidReference;
                responseData.ErrorMessages.Add("Referenced user does not exist");
            }

            UserMovie? dbWatchlistEntry = await _context.UsersMovies
                .SingleOrDefaultAsync(um => um.UserId.ToLower() == userId.ToLower() && um.MovieId == movieId);

            if (dbWatchlistEntry == null)
            {
                responseData.Status = WatchlistServiceResponseStatus.EntityNotFound;
            }
            else
            {
                try
                {
                    _context.UsersMovies.Remove(dbWatchlistEntry);
                    await _context.SaveChangesAsync();

                    responseData.Status = WatchlistServiceResponseStatus.Success;
                }
                catch (Exception e)
                {
                    // TODO: Log the exception details for further analysis and debugging
                    responseData.Status = WatchlistServiceResponseStatus.GeneralError;
                    responseData.ErrorMessages = new List<string?>() { e.Message };
                }
            }

            return responseData;
        }
    }
}
