using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Common.Utilities;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Enums;
using CinemaApp.Services.Core.Data.Movie.Request;
using CinemaApp.Services.Core.Data.Movie.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        //private readonly ApplicationDbContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly BasicModelValidator _modelValidator;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IMovieRepository movieRepository, ILogger<MovieService> logger)
        {
            _movieRepository = movieRepository;
            _modelValidator = new BasicModelValidator();
            _logger = logger;
        }

        public async Task<MovieServiceStatusResponseModel> CreateMovieAsync(CreateMovieRequestData requestData)
        {
            MovieServiceStatusResponseModel response = new MovieServiceStatusResponseModel();

            bool isInputDataValid = _modelValidator.IsValid(requestData);

            if (!isInputDataValid)
            {
                response.Status = MovieServiceResponseStatus.InvalidRequest;
                response.ErrorMessages = _modelValidator.ValidationResults
                    .Select(vr => vr.ErrorMessage);
            }
            else
            {
                Movie movie = new Movie()
                {
                    Title = requestData.Title,
                    Genre = requestData.Genre,
                    ReleaseDate = requestData.ReleaseDate,
                    Duration = requestData.Duration,
                    Description = requestData.Description,
                    Director = requestData.Director,
                    ImageUrl = requestData.ImageUrl
                };

                try
                {
                    await _movieRepository.AddAsync(movie);
                    await _movieRepository.SaveChangesAsync();

                    response.Status = MovieServiceResponseStatus.Success;
                }
                catch (DbUpdateException e)
                {
                    // TODO: Log the exception details for further analysis and debugging
                    response.Status = MovieServiceResponseStatus.GeneralError;
                    response.ErrorMessages = new List<string?>() { e.Message };
                }
            }

            return response;
        }

        public async Task<MovieExtendedDataResponseModel?> GetMovieExtendedDataByIdAsync(Guid id)
        {
            MovieExtendedDataResponseModel? responseData = null;

            Movie? dbMovie = await _movieRepository
                .FindByIdAsync(id);

            if (dbMovie != null)
            {
                responseData = new MovieExtendedDataResponseModel()
                {
                    Id = dbMovie.Id,
                    Title = dbMovie.Title,
                    Genre = dbMovie.Genre,
                    ReleaseDate = dbMovie.ReleaseDate,
                    Description = dbMovie.Description,
                    Director = dbMovie.Director,
                    ImageUrl = dbMovie.ImageUrl,
                    Duration = dbMovie.Duration
                };
            }

            return responseData;
        }

        public async Task<IEnumerable<GetAllMoviesResponseModel>> GetAllMoviesAsync()
        {
            // TODO: Implement Mapperly for auto generation of mapping code
            IEnumerable<GetAllMoviesResponseModel> moviesResponseDate = await _movieRepository
                .AllAsNoTracking()
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Genre)
                .Select(m => new GetAllMoviesResponseModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate,
                    ImageUrl = m.ImageUrl
                })
                .ToArrayAsync();

            return moviesResponseDate;
        }

        public async Task<MovieServiceStatusResponseModel> EditMovieAsync(EditMovieRequestData requestData)
        {
            MovieServiceStatusResponseModel responseData = new MovieServiceStatusResponseModel()
            {
                Status = MovieServiceResponseStatus.GeneralError,
                ErrorMessages = new List<string?>()
            };

            Movie? dbMovie = await _movieRepository
                .FindByIdAsync(requestData.Id);

            if (dbMovie == null)
            {
                responseData.Status = MovieServiceResponseStatus.NotFound;
            }

            bool isRequestDataValid = _modelValidator.IsValid(requestData);

            if (!isRequestDataValid)
            {
                responseData.Status = MovieServiceResponseStatus.InvalidRequest;
                responseData.ErrorMessages = _modelValidator.ValidationResults
                    .Select(vr => vr.ErrorMessage);
            }

            try
            {
                if (dbMovie != null)
                {
                    dbMovie.Title = requestData.Title;
                    dbMovie.Description = requestData.Description;
                    dbMovie.ImageUrl = requestData.ImageUrl;
                    dbMovie.Director = requestData.Director;
                    dbMovie.Genre = requestData.Genre;
                    dbMovie.ReleaseDate = requestData.ReleaseDate;
                    dbMovie.Duration = requestData.Duration;

                    await _movieRepository.SaveChangesAsync();

                    responseData.Status = MovieServiceResponseStatus.Success;
                }
            }
            catch (Exception e)
            {
                // TODO: Log the exception details for further analysis and debugging
                responseData.Status = MovieServiceResponseStatus.GeneralError;
                responseData.ErrorMessages = new List<string?>() { e.Message };
            }

            return responseData;
        }

        public async Task<MovieBasicDataResponseModel?> GetMovieBasicDataByIdAsync(Guid id)
        {
            MovieBasicDataResponseModel? responseData = null;
            Movie? dbMovie = await _movieRepository
                .FindByIdAsync(id);

            if (dbMovie != null)
            {
                responseData = new MovieBasicDataResponseModel()
                {
                    Id = dbMovie.Id,
                    Title = dbMovie.Title,
                    Genre = dbMovie.Genre,
                    ImageUrl = dbMovie.ImageUrl
                };
            }

            return responseData;
        }

        public async Task<MovieServiceStatusResponseModel> SoftDeleteMovieAsync(Guid id)
        {
            MovieServiceStatusResponseModel response = new MovieServiceStatusResponseModel()
            {
                Status = MovieServiceResponseStatus.GeneralError,
                ErrorMessages = new List<string?>()
            };

            Movie? dbMovie = await _movieRepository
                .FindByIdAsync(id);

            if (dbMovie == null)
            {
                response.Status = MovieServiceResponseStatus.NotFound;
                return response;
            }

            if (dbMovie.IsDeleted)
            {
                _logger.LogWarning($"Soft delete was performed for already deleted entity! Entity Id: {id}");
            }

            try
            {
                _movieRepository.SoftDelete(dbMovie);
                await _movieRepository.SaveChangesAsync();

                response.Status = MovieServiceResponseStatus.Success;
            }
            catch (Exception e)
            {
                // TODO: Log the exception details for further analysis and debugging
                response.Status = MovieServiceResponseStatus.GeneralError;
                response.ErrorMessages = new List<string?>() { e.Message };
            }

            return response;
        }

        public async Task<MovieServiceStatusResponseModel> HardDeleteMovieAsync(Guid id)
        {
            MovieServiceStatusResponseModel response = new MovieServiceStatusResponseModel()
            {
                Status = MovieServiceResponseStatus.GeneralError,
                ErrorMessages = new List<string?>()
            };

            Movie? dbMovie = await _movieRepository
                .FindByIdAsync(id);

            if (dbMovie == null)
            {
                response.Status = MovieServiceResponseStatus.NotFound;
                return response;
            }

            if (dbMovie.IsDeleted)
            {
                _logger.LogWarning($"Hard delete was performed for soft-deleted entity! Entity Id: {id}");
                response.Status = MovieServiceResponseStatus.Success;
            }
            else
            {
                try
                {
                    _movieRepository.Remove(dbMovie);
                    await _movieRepository.SaveChangesAsync();

                    response.Status = MovieServiceResponseStatus.Success;
                }
                catch (Exception e)
                {
                    // TODO: Log the exception details for further analysis and debugging
                    response.Status = MovieServiceResponseStatus.GeneralError;
                    response.ErrorMessages = new List<string?>() { e.Message };
                }
            }

            return response;
        }
    }
}
