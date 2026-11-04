using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Request;
using CinemaApp.Services.Core.Data.Movie.Response;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static CinemaApp.GCommon.ApplicationConstants;
using static CinemaApp.GCommon.InputValidationConstants;
using static CinemaApp.GCommon.InputValidationConstants.Movie;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllMoviesResponseModel> allMoviesResponseData = await _movieService.GetAllMoviesAsync();

            IEnumerable<AllMoviesIndexViewModel> allMoviesViewModel = allMoviesResponseData.Select(m =>
                new AllMoviesIndexViewModel()
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Director = m.Director,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(MovieReleaseDateFormat, CultureInfo.InvariantCulture),
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl
                });

            return View(allMoviesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] MovieFormInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, MovieReleaseDateFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                ModelState.AddModelError(nameof(MovieFormInputModel.ReleaseDate), ReleaseDateFormatMessage);

                return View(inputModel);
            }

            CreateMovieRequestData createMovieRequest = new CreateMovieRequestData()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Director = inputModel.Director,
                Description = inputModel.Description,
                Duration = inputModel.Duration,
                ImageUrl = inputModel.ImageUrl
            };

            MovieServiceStatusResponseModel operationStatusResponse =
                await _movieService.CreateMovieAsync(createMovieRequest);

            if (!operationStatusResponse.Status)
            {
                ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
