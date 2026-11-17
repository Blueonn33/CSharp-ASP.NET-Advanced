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
    }
}
