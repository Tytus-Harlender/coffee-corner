using CoffeeCorner.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class CustomerSeeder
{
    // This Seeder needs refactoring after Identity+Customer registration is set up
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CoffeeCornerDbContext>();

        if (!context.Customers.Any())
        {
            var customers = GetInitialUsers();

            //await context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE \"Users_Id_seq\" RESTART WITH 1;");

            
            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();
        }
    }

    private static List<Customer> GetInitialUsers()
    {
        List<Customer> customers = [
            new ("Alice", "Johnson", "alice.johnson@example.com", "123 Maple St", null, "New York", "USA", "+1-555-123-4567")
            {
                PublicId = Guid.NewGuid()
            }];
            // new()
            // {
            //     PublicId = Guid.NewGuid(),
            //     Name = "Bob",
            //     Surname = "Smith",
            //     Email = "bob.smith@example.com",
            //     UserName = "bob.smith@example.com",
            //     PhoneNumber = "+1-555-987-6543",
            //     AddressLine1 = "456 Oak Avenue",
            //     City = "Los Angeles",
            //     Country = "USA"
            // }, password: "Cheerup2"),
            // (new()
            // {
            //     PublicId = Guid.NewGuid(),
            //     Name = "Charlie",
            //     Surname = "Kowalski",
            //     Email = "charlie.kowalski@example.com",
            //     UserName = "charlie.kowalski@example.com",
            //     PhoneNumber = "+48-600-700-800",
            //     AddressLine1 = "12 Długa Street",
            //     City = "Warsaw",
            //     Country = "Poland"
            // }, password: "we34!@P"),
            // (new()
            // {
            //     PublicId = Guid.NewGuid(),
            //     Name = "Diana",
            //     Surname = "Lee",
            //     Email = "diana.lee@example.com",
            //     UserName = "diana.lee@example.com",
            //     AddressLine1 = "22 Queen’s Road",
            //     City = "London",
            //     Country = "UK"
            // }, password: "NoNeedForThat3")];

        return customers;
    }
}
