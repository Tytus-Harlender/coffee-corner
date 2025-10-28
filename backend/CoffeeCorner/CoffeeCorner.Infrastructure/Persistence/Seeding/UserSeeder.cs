using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public class UserSeeder
{
    public static async Task SeedAsync(CoffeeCornerDbContext context)
    {
        if (!context.Users.Any())
        {
            var users = GetInitialUsers();
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
                PasswordHash = "hashed_password_1",
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
                PasswordHash = "hashed_password_2",
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
                PasswordHash = "hashed_password_3",
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
                PasswordHash = "hashed_password_4",
                AddressLine1 = "22 Queen’s Road",
                City = "London",
                Country = "UK"
            }];

        return users;
    }
}
