using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Cinema.Response;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
