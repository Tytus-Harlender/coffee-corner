using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public class CharacteristicSeeder
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

        var roastLevel = new Characteristic
        {
            Name = "Roast Level",
            CharacteristicValues =
            [
                new() { Value = "Light" },
                new() { Value = "Medium" },
                new() { Value = "Dark" }
            ]
        };

        var flavorProfile = new Characteristic
        {
            Name = "Flavor Profile",
            CharacteristicValues =
            [
                new() { Value = "Fruity" },
                new() { Value = "Nutty" },
                new() { Value = "Chocolatey" }
            ]
        };

        var origin = new Characteristic
        {
            Name = "Origin",
            CharacteristicValues =
            [
                new() { Value = "Ethiopia" },
                new() { Value = "Brazil" },
                new() { Value = "Colombia" }
            ]
        };

        var acidity = new Characteristic
        {
            Name = "Acidity",
            CharacteristicValues =
            [
                new() { Value = "Mild" },
                new() { Value = "Bright" },
                new() { Value = "Sour" }
            ]
        };

        characteristics.AddRange(roastLevel, flavorProfile, origin, acidity);

        return characteristics;
    }
}
