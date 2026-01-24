using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public static class ProductSeeder
{
    public static async Task SeedAsync(CoffeeCornerDbContext context)
    {
        var products = GetInitialProducts(context);
        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }

    private static List<Product> GetInitialProducts(CoffeeCornerDbContext context)
    {
        var categories = context.Categories.ToList();
        var characteristics = context.CharacteristicValues.ToList();

        var products = new List<Product>
        {
            new(
                Guid.NewGuid(),
                "Golden Brew",
                39.99m,
                100,
                "Coffee beans of a great taste!",
                null,
                [categories.First(c => c.Name == "Whole Bean")],
                [
                    characteristics.First(cv => cv.Value == "Light"),
                    characteristics.First(cv => cv.Value == "Fruity"),
                    characteristics.First(cv => cv.Value == "Ethiopia"),
                    characteristics.First(cv => cv.Value == "Bright")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Dark Roast",
                29.99m,
                150,
                "Rich and bold flavor for coffee lovers.",
                null,
                [categories.First(c => c.Name == "Ground Coffee")],
                [
                    characteristics.First(cv => cv.Value == "Dark"),
                    characteristics.First(cv => cv.Value == "Chocolatey"),
                    characteristics.First(cv => cv.Value == "Brazil"),
                    characteristics.First(cv => cv.Value == "Mild")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Espresso Blend",
                34.99m,
                200,
                "Perfect blend for espresso enthusiasts.",
                null,
                [categories.First(c => c.Name == "Capsules & Pods")],
                [
                    characteristics.First(cv => cv.Value == "Medium"),
                    characteristics.First(cv => cv.Value == "Nutty"),
                    characteristics.First(cv => cv.Value == "Colombia"),
                    characteristics.First(cv => cv.Value == "Mild")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Decaf Delight",
                24.99m,
                120,
                "Smooth decaffeinated coffee.",
                null,
                [categories.First(c => c.Name == "Decaf")],
                [
                    characteristics.First(cv => cv.Value == "Medium"),
                    characteristics.First(cv => cv.Value == "Fruity"),
                    characteristics.First(cv => cv.Value == "Ethiopia"),
                    characteristics.First(cv => cv.Value == "Mild")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Instant Morning Boost",
                19.99m,
                180,
                "Quick and tasty instant coffee.",
                null,
                [categories.First(c => c.Name == "Instant Coffee")],
                [
                    characteristics.First(cv => cv.Value == "Light"),
                    characteristics.First(cv => cv.Value == "Nutty"),
                    characteristics.First(cv => cv.Value == "Brazil"),
                    characteristics.First(cv => cv.Value == "Bright")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Sampler Pack - Light Roasts",
                49.99m,
                75,
                "Try a variety of light roast coffees.",
                null,
                [categories.First(c => c.Name == "Sample Packs")],
                [
                    characteristics.First(cv => cv.Value == "Light"),
                    characteristics.First(cv => cv.Value == "Chocolatey"),
                    characteristics.First(cv => cv.Value == "Colombia"),
                    characteristics.First(cv => cv.Value == "Bright")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Sampler Pack - Dark Roasts",
                54.99m,
                60,
                "Try a variety of dark roast coffees.",
                null,
                [categories.First(c => c.Name == "Sample Packs")],
                [
                    characteristics.First(cv => cv.Value == "Dark"),
                    characteristics.First(cv => cv.Value == "Fruity"),
                    characteristics.First(cv => cv.Value == "Ethiopia"),
                    characteristics.First(cv => cv.Value == "Sour")
                ]
            ),

            new(
                Guid.NewGuid(),
                "Classic French Press",
                49.99m,
                80,
                "Durable stainless steel French Press.",
                null,
                [categories.First(c => c.Name == "French Press")]
            ),

            new(
                Guid.NewGuid(),
                "Glass French Press",
                59.99m,
                70,
                "Elegant glass-bodied French Press.",
                null,
                [categories.First(c => c.Name == "French Press")]
            ),

            new(
                Guid.NewGuid(),
                "Ceramic Pour Over",
                29.99m,
                100,
                "High-quality ceramic pour over brewer.",
                null,
                [categories.First(c => c.Name == "Pour Over")]
            ),

            new(
                Guid.NewGuid(),
                "Plastic Pour Over",
                19.99m,
                150,
                "Affordable plastic pour over brewer.",
                null,
                [categories.First(c => c.Name == "Pour Over")]
            ),

            new(
                Guid.NewGuid(),
                "Compact Espresso Machine",
                199.99m,
                50,
                "Perfect for home baristas.",
                null,
                [categories.First(c => c.Name == "Espresso Machines")]
            ),

            new(
                Guid.NewGuid(),
                "Professional Espresso Machine",
                999.99m,
                10,
                "Heavy-duty machine for coffee shops.",
                null,
                [categories.First(c => c.Name == "Coffee Grinders")]
            ),

            new(
                Guid.NewGuid(),
                "Electric Burr Grinder",
                89.99m,
                60,
                "Consistent grind for perfect coffee.",
                null,
                [categories.First(c => c.Name == "Coffee Grinders")]
            ),

            new(
                Guid.NewGuid(),
                "Manual Grinder",
                39.99m,
                90,
                "Portable hand grinder for fresh grounds.",
                null,
                [categories.First(c => c.Name == "Coffee Grinders")]
            )
        };


        return products;
    }
}