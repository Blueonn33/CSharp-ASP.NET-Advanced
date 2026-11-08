using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;

namespace CinemaApp.Web.Infrastructure.Filters
{
    public class PhoneRequiredActionFilter : IAsyncActionFilter
    {
        private readonly UserManager<IdentityUser> _userManager;

        public PhoneRequiredActionFilter(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Before Action (Request)
            if (!context.HttpContext.User?.Identity?.IsAuthenticated ?? true)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            string? userId = context.HttpContext.User!.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            IdentityUser? dbUser = await _userManager.FindByIdAsync(userId);

            if (dbUser == null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            // Key part of this filter
            if (string.IsNullOrWhiteSpace(dbUser.PhoneNumber) || dbUser.PhoneNumberConfirmed == false)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            // Moment of Action execution
            await next();

            // After Action (Response)
        }
    }
}
