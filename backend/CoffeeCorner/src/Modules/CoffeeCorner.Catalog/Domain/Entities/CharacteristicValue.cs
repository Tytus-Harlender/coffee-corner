using CoffeeCorner.Catalog.Domain.Exceptions;
using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Entities;

public sealed class CharacteristicValue : BaseEntity
{
    public string Value { get; private set; } = string.Empty;
    public int CharacteristicId { get; private set; }
    public Characteristic Characteristic { get; private set; } = null!;
    public ICollection<Product> Products { get; private set; } = [];

    private CharacteristicValue()
    {
        
    }
    
    public CharacteristicValue(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new CharacteristicValueException("Value cannot be null or empty.");

        Value = value;
    }
}