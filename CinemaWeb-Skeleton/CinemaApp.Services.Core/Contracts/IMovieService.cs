using CinemaApp.Services.Core.Data.Movie.Request;
using CinemaApp.Services.Core.Data.Movie.Response;

namespace CinemaApp.Services.Core.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<GetAllMoviesResponseModel>> GetAllMoviesAsync();

        Task<MovieServiceStatusResponseModel> CreateMovieAsync(CreateMovieRequestData requestData);

        Task<MovieExtendedDataResponseModel?> GetMovieExtendedDataByIdAsync(Guid id);

        Task<MovieServiceStatusResponseModel> EditMovieAsync(EditMovieRequestData requestData);

        Task<MovieBasicDataResponseModel?> GetMovieBasicDataByIdAsync(Guid id);

        Task<MovieServiceStatusResponseModel> SoftDeleteMovieAsync(Guid id);

        Task<MovieServiceStatusResponseModel> HardDeleteMovieAsync(Guid id);
    }
}
