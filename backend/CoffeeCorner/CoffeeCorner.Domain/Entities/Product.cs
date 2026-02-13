using CoffeeCorner.Domain.Exceptions;

namespace CoffeeCorner.Domain.Entities;

public sealed class Product : BaseEntity
{
    public Guid PublicId { get; init; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string? ImageUrl { get; private set; }
    public int StockQuantity { get; private set; }

    private Product()
    {
    }

    public Product(
        Guid publicId,
        string name,
        decimal price,
        int stockQuantity,
        string? description = null,
        string? imageUrl = null,
        List<Category>? categories = null,
        List<CharacteristicValue>? characteristicValues = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ProductCreationException("Product name cannot be null or empty");

        if (price <= 0)
            throw new ProductCreationException("Price must be positive");

        if (stockQuantity < 0)
            throw new ProductCreationException("Stock cannot be negative");

        PublicId = publicId;
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;

        Description = description ?? string.Empty;
        ImageUrl = imageUrl ?? string.Empty;
        Categories = categories ?? [];
        CharacteristicValues = characteristicValues ?? [];
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new StockDecreaseException("Quantity must be positive");

        if (StockQuantity < quantity)
            throw new StockDecreaseException("Insufficient stock");

        StockQuantity -= quantity;
    }

    public ICollection<Category> Categories { get; private set; } = [];
    public ICollection<CharacteristicValue> CharacteristicValues { get; private set; } = [];
}