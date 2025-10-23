namespace CoffeeCorner.Domain.Entities;

public class CharacteristicValue : BaseEntity
{
    public string Value { get; set; } = string.Empty;
    public Characteristic Characteristic { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = [];
}
