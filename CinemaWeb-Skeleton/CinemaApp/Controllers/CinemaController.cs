using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Cinema.Response;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.CinemaMovie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : BaseController
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllCinemasResponseModel> responseData = await _cinemaService.GetAllCinemasAsync();
            IEnumerable<CinemaIndexViewModel> indexViewModel = responseData
                .Select(c => new CinemaIndexViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location
                })
                .ToArray();

            return View(indexViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Program([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            CinemaProgramResponseModel? responseData = await _cinemaService
                .GetCinemaProgramByIdAsync(id.Value);

            if (responseData == null)
            {
                return NotFound();
            }

            IEnumerable<CinemaProgramViewModel> programViewModel = responseData.Movies
                .Select(m => new CinemaProgramViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl
                })
                .ToArray();

            return View(programViewModel);
        }
    }
}
