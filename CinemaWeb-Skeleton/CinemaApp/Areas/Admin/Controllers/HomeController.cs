using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
