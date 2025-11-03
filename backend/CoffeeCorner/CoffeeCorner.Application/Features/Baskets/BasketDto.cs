namespace CoffeeCorner.Application.Features.Baskets;

public class BasketDto
{
    public Guid UserPublicId { get; set; }
    public IEnumerable<object> BasketItems { get; set; } = [];
}
