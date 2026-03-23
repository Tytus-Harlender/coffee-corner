using CoffeeCorner.Identity.Persistence;
using CoffeeCorner.Identity.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;


public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider services, CancellationToken ct = default)
    {
        var users = new[]
        {
            new { Email = "alice.johnson@example.com", PublicId = Guid.Parse("11111111-1111-1111-1111-111111111111") },
            new { Email = "bob.smith@example.com", PublicId = Guid.Parse("22222222-2222-2222-2222-222222222222") },
            new { Email = "charlie.kowalski@example.com", PublicId = Guid.Parse("33333333-3333-3333-3333-333333333333") },
            new { Email = "diana.lee@example.com", PublicId = Guid.Parse("44444444-4444-4444-4444-444444444444") }
        };

        using var scope = services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        
        foreach (var u in users)
        {
            var existing = await userManager.FindByEmailAsync(u.Email);
            if (existing != null)
                continue;

            var user = new User
            {
                UserName = u.Email,
                Email = u.Email,
                PublicId = u.PublicId
            };

            await userManager.CreateAsync(user, "Test123!");
        }
    }
}