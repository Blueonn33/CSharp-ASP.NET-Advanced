using IdentityTest.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityTest.Controllers
{
    [Authorize]
    public class EmployeeController(
        UserManager<ApplicationUser> _userManager,
        SignInManager<ApplicationUser> _signInManager) : Controller
    {
        public async Task<IActionResult> SetEmployeeNumber(string number)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                if (User.HasClaim(c => c.Type == "EmployeeNumber"))
                {
                    string employeeNumber = User.Claims.First(c => c.Type == "EmployeeNumber").Value;

                    if (employeeNumber != number)
                    {
                        await _userManager.ReplaceClaimAsync(
                            user,
                            new Claim("EmployeeNumber", employeeNumber),
                            new Claim("EmployeeNumber", number));

                        await _signInManager.RefreshSignInAsync(user);
                    }
                }
                else
                {
                    await _userManager.AddClaimAsync(user, new Claim("EmployeeNumber", number));
                    await _signInManager.RefreshSignInAsync(user);
                }
            }

            ViewBag.Title = "Set Employee Number";
            ViewBag.Message = $"Number set to {number}";

            return PartialView("_Employee");
        }

        [Authorize(Policy = "HasEmployeeNumber")]
        public IActionResult CheckIfEmployee()
        {
            ViewBag.Title = "Check if employee exists";
            ViewBag.Message = $"Yes, I'm an Employee";

            return PartialView("_Employee");
        }

        [Authorize(Policy = "IsSpecialEmployee")]
        public IActionResult CheckIfSpecialEmployee()
        {
            ViewBag.Title = "Check if this employee is special";
            ViewBag.Message = $"Yes, I'm Special";

            return PartialView("_Employee");
        }
    }
}
