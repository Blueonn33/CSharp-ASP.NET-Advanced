using IdentityTest.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTest.Controllers
{
    [Authorize]
    public class UserController(
        UserManager<ApplicationUser> _userManager,
        RoleManager<ApplicationRole> _roleManager,
        SignInManager<ApplicationUser> _signInManager) : Controller
    {
        public async Task<IActionResult> CreateRole(string roleName, string label)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new ApplicationRole
                {
                    Name = roleName,
                    Label = label
                };

                var result = _roleManager.CreateAsync(role);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AddUserToRole(string roleName)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                if (!await _userManager.IsInRoleAsync(user, roleName))
                {
                    var result = await _userManager.AddToRoleAsync(user, roleName);

                    await _signInManager.RefreshSignInAsync(user);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult CheckAdmin()
        {
            ViewBag.Title = "Check If I'm an Admin";
            ViewBag.Message = "Yes, I'm an Admin";

            return PartialView("_Employee");
        }
    }
}
