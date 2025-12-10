using CoffeeCorner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public class UserSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CoffeeCornerDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

        await RoleSeeder.SeedRoles(roleManager);

        if (!context.Users.Any())
        {
            var users = GetInitialUsers();

            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE \"Users_Id_seq\" RESTART WITH 1;");

            foreach (var (user, password) in users)
            {
                var result = await userManager.CreateAsync(user, password ?? "default_password");

                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create user {user.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }

        var adminRole = await roleManager.FindByNameAsync("Admin");

        if (adminRole is not null)
        {
            bool adminExists = await context.UserRoles
                .AnyAsync(ur => ur.RoleId == adminRole.Id);

            if (!adminExists)
            {
                var adminUser = new User
                {
                    PublicId = Guid.NewGuid(),
                    Name = "James",
                    Surname = "Watch",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PhoneNumber = "+49859763998",
                    AddressLine1 = "12 Forest Lane",
                    City = "Glasgow",
                    Country = "UK"
                };

                var result = await userManager.CreateAsync(adminUser, "AdminPassword123");

                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }

                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
        else
        {
            throw new Exception("Admin role not found during user seeding.");
        }
    }

    private static List<(User,string)> GetInitialUsers()
    {
        List<(User user,string password)> users = [
            (new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Alice",
                Surname = "Johnson",
                Email = "alice.johnson@example.com",
                UserName = "alice.johnson@example.com",
                PhoneNumber = "+1-555-123-4567",
                AddressLine1 = "123 Maple St",
                City = "New York",
                Country = "USA"
            }, password: "ilikeCats1"),
            (new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Bob",
                Surname = "Smith",
                Email = "bob.smith@example.com",
                UserName = "bob.smith@example.com",
                PhoneNumber = "+1-555-987-6543",
                AddressLine1 = "456 Oak Avenue",
                City = "Los Angeles",
                Country = "USA"
            }, password: "Cheerup2"),
            (new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Charlie",
                Surname = "Kowalski",
                Email = "charlie.kowalski@example.com",
                UserName = "charlie.kowalski@example.com",
                PhoneNumber = "+48-600-700-800",
                AddressLine1 = "12 Długa Street",
                City = "Warsaw",
                Country = "Poland"
            }, password: "we34!@P"),
            (new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Diana",
                Surname = "Lee",
                Email = "diana.lee@example.com",
                UserName = "diana.lee@example.com",
                AddressLine1 = "22 Queen’s Road",
                City = "London",
                Country = "UK"
            }, password: "NoNeedForThat3")];

        return users;
    }
}
