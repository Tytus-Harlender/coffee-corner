using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Persistence.Seeding;

public class ProductSeeder
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
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Golden Brew",
                Description = "Coffee beans of a great taste!",
                Price = 39.99m,
                StockQuantity = 100,
                Categories = [categories.First(c => c.Name == "Whole Bean")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Light"),
                    characteristics.First(cv => cv.Value == "Fruity"),
                    characteristics.First(cv => cv.Value == "Ethiopia"),
                    characteristics.First(cv => cv.Value == "Bright")
                ]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Dark Roast",
                Description = "Rich and bold flavor for coffee lovers.",
                Price = 29.99m,
                StockQuantity = 150,
                Categories = [categories.First(c => c.Name == "Ground Coffee")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Dark"),
                    characteristics.First(cv => cv.Value == "Chocolatey"),
                    characteristics.First(cv => cv.Value == "Brazil"),
                    characteristics.First(cv => cv.Value == "Mild")
                ]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Espresso Blend",
                Description = "Perfect blend for espresso enthusiasts.",
                Price = 34.99m,
                StockQuantity = 200,
                Categories = [categories.First(c => c.Name == "Capsules & Pods")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Medium"),
                    characteristics.First(cv => cv.Value == "Nutty"),
                    characteristics.First(cv => cv.Value == "Colombia"),
                    characteristics.First(cv => cv.Value == "Mild")
                ]
            },
        
            // Additional products for other coffee subcategories:
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Decaf Delight",
                Description = "Smooth decaffeinated coffee.",
                Price = 24.99m,
                StockQuantity = 120,
                Categories = [categories.First(c => c.Name == "Decaf")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Medium"),
                    characteristics.First(cv => cv.Value == "Fruity"),
                    characteristics.First(cv => cv.Value == "Ethiopia"),
                    characteristics.First(cv => cv.Value == "Mild")
                ]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Instant Morning Boost",
                Description = "Quick and tasty instant coffee.",
                Price = 19.99m,
                StockQuantity = 180,
                Categories = [categories.First(c => c.Name == "Instant Coffee")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Light"),
                    characteristics.First(cv => cv.Value == "Nutty"),
                    characteristics.First(cv => cv.Value == "Brazil"),
                    characteristics.First(cv => cv.Value == "Bright")
                ]
            },
        
            // Sample Packs products
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Sampler Pack - Light Roasts",
                Description = "Try a variety of light roast coffees.",
                Price = 49.99m,
                StockQuantity = 75,
                Categories = [categories.First(c => c.Name == "Sample Packs")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Light"),
                    characteristics.First(cv => cv.Value == "Chocolatey"),
                    characteristics.First(cv => cv.Value == "Colombia"),
                    characteristics.First(cv => cv.Value == "Bright")
                ]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Sampler Pack - Dark Roasts",
                Description = "Try a variety of dark roast coffees.",
                Price = 54.99m,
                StockQuantity = 60,
                Categories = [categories.First(c => c.Name == "Sample Packs")],
                CharacteristicValues =
                [
                    characteristics.First(cv => cv.Value == "Dark"),
                    characteristics.First(cv => cv.Value == "Fruity"),
                    characteristics.First(cv => cv.Value == "Ethiopia"),
                    characteristics.First(cv => cv.Value == "Sour")
                ]
            },
        
            // Brewing Equipment - Manual Brewing - French Press
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Classic French Press",
                Description = "Durable stainless steel French Press.",
                Price = 49.99m,
                StockQuantity = 80,
                Categories = [categories.First(c => c.Name == "French Press")]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Glass French Press",
                Description = "Elegant glass-bodied French Press.",
                Price = 59.99m,
                StockQuantity = 70,
                Categories = [categories.First(c => c.Name == "French Press")]
            },
        
            // Brewing Equipment - Manual Brewing - Pour Over
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Ceramic Pour Over",
                Description = "High-quality ceramic pour over brewer.",
                Price = 29.99m,
                StockQuantity = 100,
                Categories = [categories.First(c => c.Name == "Pour Over")]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Plastic Pour Over",
                Description = "Affordable plastic pour over brewer.",
                Price = 19.99m,
                StockQuantity = 150,
                Categories = [categories.First(c => c.Name == "Pour Over")]
            },
        
            // Espresso Machines
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Compact Espresso Machine",
                Description = "Perfect for home baristas.",
                Price = 199.99m,
                StockQuantity = 50,
                Categories = [categories.First(c => c.Name == "Espresso Machines")]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Professional Espresso Machine",
                Description = "Heavy-duty machine for coffee shops.",
                Price = 999.99m,
                StockQuantity = 10,
                Categories = [categories.First(c => c.Name == "Coffee Grinders")]
            },
        
            // Coffee Grinders
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Electric Burr Grinder",
                Description = "Consistent grind for perfect coffee.",
                Price = 89.99m,
                StockQuantity = 60,
                Categories = [categories.First(c => c.Name == "Coffee Grinders")]
            },
            new() {
                PublicId = Guid.NewGuid(),
                Name = "Manual Grinder",
                Description = "Portable hand grinder for fresh grounds.",
                Price = 39.99m,
                StockQuantity = 90,
                Categories = [categories.First(c => c.Name == "Coffee Grinders")]
            }
        };

        return products;
    }
}