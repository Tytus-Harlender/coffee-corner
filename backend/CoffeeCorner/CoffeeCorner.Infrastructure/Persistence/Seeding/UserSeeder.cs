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

        if (!context.Users.Any())
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var users = GetInitialUsers();

            await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE \"Users_Id_seq\" RESTART WITH 1;");
            
            foreach (var user in users)
            {
                await userManager.CreateAsync(user, user.PasswordHash ?? GeneratePasswordHash("default_password"));
            }

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }

    private static List<User> GetInitialUsers()
    {
        List<User> users = [
            new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Alice",
                Surname = "Johnson",
                Email = "alice.johnson@example.com",
                PasswordHash = GeneratePasswordHash("ilikeCats1"),
                PhoneNumber = "+1-555-123-4567",
                AddressLine1 = "123 Maple St",
                City = "New York",
                Country = "USA"
            },
            new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Bob",
                Surname = "Smith",
                Email = "bob.smith@example.com",
                PasswordHash = GeneratePasswordHash("Cheerup2"),
                PhoneNumber = "+1-555-987-6543",
                AddressLine1 = "456 Oak Avenue",
                City = "Los Angeles",
                Country = "USA"
            },
            new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Charlie",
                Surname = "Kowalski",
                Email = "charlie.kowalski@example.com",
                PasswordHash = GeneratePasswordHash("we34!@P"),
                PhoneNumber = "+48-600-700-800",
                AddressLine1 = "12 Długa Street",
                City = "Warsaw",
                Country = "Poland"
            },
            new()
            {
                PublicId = Guid.NewGuid(),
                Name = "Diana",
                Surname = "Lee",
                Email = "diana.lee@example.com",
                PasswordHash = GeneratePasswordHash("NoNeedForThat"),
                AddressLine1 = "22 Queen’s Road",
                City = "London",
                Country = "UK"
            }];

        return users;
    }

    private static string GeneratePasswordHash(string password)
    {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(null!, password);
    }
}
