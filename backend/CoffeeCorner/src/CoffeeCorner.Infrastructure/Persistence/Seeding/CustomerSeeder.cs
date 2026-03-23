using CoffeeCorner.Customers.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class CustomerSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var customerContext = scope.ServiceProvider.GetRequiredService<CoffeeCornerDbContext>();

        if (!customerContext.Customers.Any())
        {
            var customers = GetInitialCustomers();
            
            await customerContext.Customers.AddRangeAsync(customers);
            await customerContext.SaveChangesAsync();
        }
    }

    private static List<Customer> GetInitialCustomers()
    {
        return new List<Customer>
        {
            new("Alice", "Johnson", "alice.johnson@example.com", "123 Maple St", null, "New York", "USA", "+1-555-123-4567")
            {
                PublicId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new("Bob", "Smith", "bob.smith@example.com", "456 Oak Avenue", null, "Los Angeles", "USA", "+1-555-987-6543")
            {
                PublicId = Guid.Parse("22222222-2222-2222-2222-222222222222")
            },
            new("Charlie", "Kowalski", "charlie.kowalski@example.com", "12 Długa Street", null, "Warsaw", "Poland", "+48-600-700-800")
            {
                PublicId = Guid.Parse("33333333-3333-3333-3333-333333333333")
            },
            new("Diana", "Lee", "diana.lee@example.com", "22 Queen’s Road", null, "London", "UK", null)
            {
                PublicId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            }
        };
    }
}
