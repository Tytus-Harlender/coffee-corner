namespace CoffeeCorner.Application.Features.Baskets;

public class BasketDto
{
    public Guid UserPublicId { get; set; }
    public IEnumerable<BasketItemDto> BasketItems { get; set; } = [];
}
