using CinemaApp.Services.Core.Data.Projection.Response;

namespace CinemaApp.Services.Core.Contracts
{
    public interface IProjectionService
    {
        Task<IEnumerable<GetProjectionDatesResponseModel>> GetProjectionDatesAsync(Guid cinemaId, Guid movieId);
    }
}
