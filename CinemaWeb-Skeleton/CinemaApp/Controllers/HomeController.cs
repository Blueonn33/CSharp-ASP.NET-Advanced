using CinemaApp.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Web.Controllers
{
    using CinemaApp.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [ServiceFilter(typeof(PhoneRequiredActionFilter))]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            int effectiveStatusCode = statusCode ?? HttpContext.Response.StatusCode;
            if (effectiveStatusCode < 400)
            {
                effectiveStatusCode = StatusCodes.Status500InternalServerError;
            }

            HttpContext.Response.StatusCode = effectiveStatusCode;
            ViewData["StatusCode"] = effectiveStatusCode;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
