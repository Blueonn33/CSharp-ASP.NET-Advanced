using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Security.Claims;

namespace CinemaApp.Web.Infrastructure.Filters
{
    public class PhoneRequiredActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Before Action (Request)
            if (context.HttpContext.User?.Identity?.IsAuthenticated ?? false)
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

            UserManager<IdentityUser>? userManager = context.HttpContext.RequestServices
                .GetService<UserManager<IdentityUser>>();

            if (userManager == null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            IdentityUser? dbUser = userManager.FindByIdAsync(userId)
                .GetAwaiter()
                .GetResult();

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

            base.OnActionExecuting(context);
        }
    }
}
