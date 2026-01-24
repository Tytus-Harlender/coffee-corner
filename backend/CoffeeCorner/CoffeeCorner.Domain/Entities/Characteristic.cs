using CoffeeCorner.Domain.Exceptions;

namespace CoffeeCorner.Domain.Entities;

public class Characteristic : BaseEntity
{
    public string Name { get; private set; }

    public ICollection<CharacteristicValue> CharacteristicValues { get; private set; } = [];

    private Characteristic()
    {
    }

    public Characteristic(
        string name)
    {        
        if (string.IsNullOrWhiteSpace(name))
            throw new CharacteristicCreationException("Characteristic name cannot be null or empty.");

        Name = name;
    }
    
    public void AddValues(ICollection<string> values)
    {
        if (values == null)
            throw new CharacteristicCreationException("Characteristic values cannot be null.");
        
        foreach (var value in values)
        {
            this.CharacteristicValues.Add(new CharacteristicValue(value));
        }
    }
}
