using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Common.Utilities;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Request;
using CinemaApp.Services.Core.Data.Movie.Response;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly BasicModelValidator _modelValidator;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
            _modelValidator = new BasicModelValidator();
        }

        public async Task<MovieServiceStatusResponseModel> CreateMovieAsync(CreateMovieRequestData requestData)
        {
            MovieServiceStatusResponseModel response = new MovieServiceStatusResponseModel();

            bool isInputDataValid = BasicModelValidator.IsValid(requestData);

            if (!isInputDataValid)
            {
                response.Status = false;
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
                    await _context.Movies.AddAsync(movie);
                    await _context.SaveChangesAsync();

                    response.Status = true;
                }
                catch (DbUpdateException e)
                {
                    // TODO: Log the exception details for further analysis and debugging
                    response.Status = false;
                    response.ErrorMessages = new List<string?>() { e.Message };
                }
            }

            return response;
        }

        public async Task<IEnumerable<GetAllMoviesResponseModel>> GetAllMoviesAsync()
        {
            // TODO: Implement Mapperly for auto generation of mapping code
            IEnumerable<GetAllMoviesResponseModel> moviesResponseDate = await _context.Movies
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
    }
}
