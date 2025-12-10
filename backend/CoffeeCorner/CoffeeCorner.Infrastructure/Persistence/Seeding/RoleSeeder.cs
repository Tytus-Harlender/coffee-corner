using Microsoft.AspNetCore.Identity;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public class RoleSeeder
{
    public static async Task SeedRoles(RoleManager<IdentityRole<int>> roleManager)
    {
        string[] roleNames = { "Admin", "Manager" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole<int>(roleName));

                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create {roleName} role: "
                        + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
