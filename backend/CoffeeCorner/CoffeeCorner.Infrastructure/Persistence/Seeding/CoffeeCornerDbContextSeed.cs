namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class CoffeeCornerDbContextSeed
{
    public static async Task SeedAsync(CoffeeCornerDbContext context)
    {
        if (!context.Products.Any())
        {
            context.Products.AddRange(
            [
                new Domain.Entities.Product
            {
                PublicId = Guid.NewGuid(),
                Name = "Golden Brew",
                Description = "Coffee beans of a great taste!",
                Price = 39.99m
            },
            new Domain.Entities.Product
            {
                PublicId = Guid.NewGuid(),
                Name = "Dark Roast",
                Description = "Rich and bold flavor for coffee lovers.",
                Price = 29.99m
            },
            new Domain.Entities.Product
            {
                PublicId = Guid.NewGuid(),
                Name = "Espresso Blend",
                Description = "Perfect blend for espresso enthusiasts.",
                Price = 34.99m
            }
            ]);

            await context.SaveChangesAsync();
        }
    }
}
