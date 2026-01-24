using CoffeeCorner.Domain.Exceptions;

namespace CoffeeCorner.Domain.Entities;

public class CharacteristicValue : BaseEntity
{
    public string Value { get; private set; } = string.Empty;
    public Characteristic Characteristic { get; private set; } = null!;

    private CharacteristicValue()
    {
        
    }
    
    internal CharacteristicValue(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new CharacteristicValueException("Value cannot be null or empty.");

        Value = value;
    }
}
