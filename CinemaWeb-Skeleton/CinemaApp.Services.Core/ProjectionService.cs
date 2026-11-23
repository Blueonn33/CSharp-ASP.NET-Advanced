using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Projection.Response;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core
{
    public class ProjectionService : IProjectionService
    {
        private readonly ICinemaMovieRepository _cinemaMovieRepository;

        public ProjectionService(ICinemaMovieRepository cinemaMovieRepository)
        {
            _cinemaMovieRepository = cinemaMovieRepository;
        }

        public async Task<IEnumerable<GetProjectionDatesResponseModel>> GetProjectionDatesAsync(Guid cinemaId, Guid movieId)
        {
            IEnumerable<GetProjectionDatesResponseModel> responseData = await _cinemaMovieRepository
                .AllAsNoTracking()
                .Where(cm => cm.CinemaId == cinemaId && cm.MovieId == movieId)
                .Select(cm => new GetProjectionDatesResponseModel()
                {
                    Id = cm.Id,
                    CinemaId = cinemaId,
                    MovieId = movieId,
                    Showtime = cm.Showtime
                })
                .ToArrayAsync();

            return responseData;
        }

        public async Task<int> GetProjectionAvailabilityAsync(Guid projectionId)
        {
            CinemaMovie? dbProjection = await _cinemaMovieRepository
                .AllAsNoTracking()
                .SingleOrDefaultAsync(cm => cm.Id == projectionId);

            if (dbProjection == null)
            {
                return 0;
            }

            return dbProjection.AvailableTickets;
        }
    }
}
