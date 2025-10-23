using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public class CategorySeeder
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

        var coffeeCategory = new Category
        {
            Name = "Coffee",
            SubCategories = []
        };

        var wholeBean = new Category {Name = "Whole Bean", ParentCategory = coffeeCategory };
        var groundCoffee = new Category {Name = "Ground Coffee", ParentCategory = coffeeCategory };
        var capsulesPods = new Category {Name = "Capsules & Pods", ParentCategory = coffeeCategory };
        var decaf = new Category {Name = "Decaf", ParentCategory = coffeeCategory };
        var instantCoffee = new Category {Name = "Instant Coffee", ParentCategory = coffeeCategory };
        var samplePacks = new Category {Name = "Sample Packs", ParentCategory = coffeeCategory };

        coffeeCategory.SubCategories = [wholeBean, groundCoffee, capsulesPods, decaf, instantCoffee, samplePacks];

        categories.AddRange([coffeeCategory, wholeBean, groundCoffee, capsulesPods, decaf, instantCoffee, samplePacks]);

        var brewingEquipment = new Category
        {
            Name = "Brewing Equipment",
            SubCategories = []
        };

        var manualBrewing = new Category {Name = "Manual Brewing", ParentCategory = brewingEquipment };
        var espressoMachines = new Category {Name = "Espresso Machines", ParentCategory = brewingEquipment };
        var coffeeGrinders = new Category {Name = "Coffee Grinders", ParentCategory = brewingEquipment };
        var coldBrewMakers = new Category {Name = "Cold Brew Makers", ParentCategory = brewingEquipment };

        var frenchPress = new Category {Name = "French Press", ParentCategory = manualBrewing };
        var pourOver = new Category {Name = "Pour Over", ParentCategory = manualBrewing };
        var mokkaPot = new Category {Name = "Mokka Pot", ParentCategory = manualBrewing };
        var aeroPress = new Category {Name = "AeroPress", ParentCategory = manualBrewing };

        manualBrewing.SubCategories = [frenchPress, pourOver, mokkaPot, aeroPress];

        brewingEquipment.SubCategories = [
            manualBrewing, espressoMachines, coffeeGrinders, coldBrewMakers
        ];

        categories.AddRange([brewingEquipment, manualBrewing, espressoMachines, coffeeGrinders, coldBrewMakers, frenchPress, pourOver, mokkaPot, aeroPress]);

        return categories;
    }
}
