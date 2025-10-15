namespace CoffeeCorner.API.Features.CoffeeTypes;

public interface ICoffeeTypesService
{
    IEnumerable<string> GetCoffeeTypes();
}
