using Microsoft.AspNetCore.Mvc;

namespace IdentityTest.Areas.Admin.Controllers
{
    public class SettingsController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
