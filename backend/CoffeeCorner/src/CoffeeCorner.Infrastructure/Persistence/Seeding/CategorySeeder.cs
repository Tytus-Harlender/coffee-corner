using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class CategorySeeder
{
    public static async Task SeedAsync(CoffeeCornerDbContext context)
    {
        var categories = GetInitialCategories();
        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();
    }

    private static List<Category> GetInitialCategories()
    {
        var categories = new List<Category>();

        //coffee category hierarchy
        var coffeeCategory = new Category("Coffee", null);

        var wholeBean = new Category("Whole Bean", coffeeCategory);
        var groundCoffee = new Category("Ground Coffee", coffeeCategory);
        var capsulesPods = new Category("Capsules & Pods", coffeeCategory);
        var decaf = new Category("Decaf", coffeeCategory);
        var instantCoffee = new Category("Instant Coffee", coffeeCategory);
        var samplePacks = new Category("Sample Packs", coffeeCategory);

        categories.AddRange([coffeeCategory, wholeBean, groundCoffee, capsulesPods, decaf, instantCoffee, samplePacks]);

        // Brewing Equipment category hierarchy
        var brewingEquipment = new Category("Brewing Equipment");

        var manualBrewing = new Category("Manual Brewing", brewingEquipment);
        var espressoMachines = new Category("Espresso Machines", brewingEquipment);
        var coffeeGrinders = new Category("Coffee Grinders", brewingEquipment);
        var coldBrewMakers = new Category("Cold Brew Makers", brewingEquipment);

        var frenchPress = new Category("French Press", manualBrewing);
        var pourOver = new Category("Pour Over", manualBrewing);
        var mokkaPot = new Category("Mokka Pot", manualBrewing);
        var aeroPress = new Category("AeroPress", manualBrewing);
        
        categories.AddRange([brewingEquipment, manualBrewing, espressoMachines, coffeeGrinders, coldBrewMakers, frenchPress, pourOver, mokkaPot, aeroPress]);

        return categories;
    }
}
