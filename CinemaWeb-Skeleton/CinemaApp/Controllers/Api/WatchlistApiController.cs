using CinemaApp.Services.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistApiController : ControllerBase
    {
        private readonly IWatchlistService _watchlistService;

        public WatchlistApiController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        [ProducesResponseType<bool>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("[action]/{movieId}")]
        public async Task<ActionResult<bool>> IsInWatchlist(Guid? movieId)
        {
            if (movieId == null)
            {
                return BadRequest();
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                // Return true to hide the "Add to Watchlist" btn for unauthenticated users
                return true;
            }

            bool isInWatchlist = await _watchlistService.IsMovieInUserWatchlistAsync(userId, movieId.Value);

            return isInWatchlist;
        }

        private string? GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
