using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Cinema.Response;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaService(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<IEnumerable<GetAllCinemasResponseModel>> GetAllCinemasAsync()
        {
            IEnumerable<GetAllCinemasResponseModel> responseData = await _cinemaRepository
                .AllAsNoTracking()
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Location)
                .Select(c => new GetAllCinemasResponseModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location
                })
                .ToArrayAsync();

            return responseData;
        }

        public async Task<CinemaProgramResponseModel?> GetCinemaProgramByIdAsync(Guid cinemaId)
        {
            CinemaProgramResponseModel? responseData = null;

            Cinema? dbCinema = await _cinemaRepository
                .AllAsNoTracking()
                .Include(c => c.CinemaProjections)
                .ThenInclude(p => p.Movie)
                .SingleOrDefaultAsync(c => c.Id == cinemaId);

            if (dbCinema != null)
            {
                IEnumerable<CinemaMovieResponseData> movies = dbCinema.CinemaProjections
                    .Select(p => p.Movie)
                    .Select(m => new CinemaMovieResponseData()
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Director = m.Director,
                        ImageUrl = m.ImageUrl,
                    })
                    .OrderBy(m => m.Title)
                    .ThenBy(m => m.Id)
                    .ToArray();

                responseData = new CinemaProgramResponseModel()
                {
                    Movies = movies
                };
            }

            return responseData;
        }
    }
}
