namespace CoffeeCorner.API.Features.CoffeeTypes;

public class CoffeeTypesService : ICoffeeTypesService
{
    private static readonly string[] CoffeeTypes =
    [
        "Arabica", "Robusta"
    ];

    public IEnumerable<string> GetCoffeeTypes()
    {
        return [.. CoffeeTypes];
    }
}
