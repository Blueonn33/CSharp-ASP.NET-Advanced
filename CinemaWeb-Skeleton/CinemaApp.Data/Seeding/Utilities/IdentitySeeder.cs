using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Data.Seeding.Utilities
{
    public class IdentitySeeder
    {
        public static string[] DefaultRoles = new[] { "User", "Manager", "Admin" };

        public static void SeedRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var roleName in DefaultRoles)
            {
                bool roleExists = roleManager.RoleExistsAsync(roleName)
                    .GetAwaiter()
                    .GetResult();

                if (roleExists)
                {
                    continue;
                }

                IdentityRole identityRole = new IdentityRole(roleName);

                IdentityResult result = roleManager.CreateAsync(identityRole)
                    .GetAwaiter()
                    .GetResult();

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Role {roleName} cannot be created");
                }
            }
        }
    }
}
