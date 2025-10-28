namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class SeedingManager
{
    public static async Task SeedAsync(CoffeeCornerDbContext context)
    {
        if (!context.Categories.Any())
        {
            await CategorySeeder.SeedAsync(context);
        }
        if (!context.Characteristics.Any())
        {
            await CharacteristicSeeder.SeedAsync(context);
        }
        if (!context.Products.Any())
        {
            await ProductSeeder.SeedAsync(context);
        }
        if (!context.Users.Any())
        {
            await UserSeeder.SeedAsync(context);
        }
    }
}
