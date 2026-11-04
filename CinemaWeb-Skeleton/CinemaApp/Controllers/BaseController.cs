using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        protected string? GetUserEmail()
        {
            return User.FindFirstValue(ClaimTypes.Email);
        }

        protected bool IsUserAuthenticated()
        {
            return User.Identity?.IsAuthenticated ?? false;
        }
    }
}
