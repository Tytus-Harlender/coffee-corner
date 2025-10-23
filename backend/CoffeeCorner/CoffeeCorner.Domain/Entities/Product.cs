namespace CoffeeCorner.Domain.Entities;

public class Product : BaseEntity
{
    public Guid PublicId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public int StockQuantity { get; set; }

    public ICollection<Category> Categories { get; set; } = [];
    public ICollection<CharacteristicValue> CharacteristicValues { get; set; } = [];
}
