namespace CoffeeCorner.Domain.Entities;

public class Characteristic : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<CharacteristicValue> CharacteristicValues { get; set; } = [];
}
