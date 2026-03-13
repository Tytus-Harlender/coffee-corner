using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class CharacteristicSeeder
{
    public static async Task SeedAsync(CoffeeCornerDbContext context)
    {
        var characteristics = GetInitialCharacteristics();
        context.Characteristics.AddRange(characteristics);
        await context.SaveChangesAsync();
    }

    private static List<Characteristic> GetInitialCharacteristics()
    {
        var characteristics = new List<Characteristic>();

        var roastLevel = new Characteristic("Roast Level");
        roastLevel.AddValues(["Light","Medium","Dark"]);

        var flavorProfile = new Characteristic("Flavor Profile");
        flavorProfile.AddValues(["Fruity", "Nutty", "Chocolatey"]);

        var origin = new Characteristic("Origin");
        origin.AddValues(["Ethiopia", "Brazil", "Colombia"]);

        var acidity = new Characteristic("Acidity");
        acidity.AddValues(["Mild", "Bright", "Sour"]);

        characteristics.AddRange(roastLevel, flavorProfile, origin, acidity);

        return characteristics;
    }
}
