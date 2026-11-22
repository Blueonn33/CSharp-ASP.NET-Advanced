using CinemaApp.Services.Core.Data.Cinema.Response;

namespace CinemaApp.Services.Core.Contracts
{
    public interface ICinemaService
    {
        Task<IEnumerable<GetAllCinemasResponseModel>> GetAllCinemasAsync();

        Task<CinemaProgramResponseModel?> GetCinemaProgramByIdAsync(Guid cinemaId);

        Task<string?> GetCinemaNameByIdAsync(Guid cinemaId);
    }
}
