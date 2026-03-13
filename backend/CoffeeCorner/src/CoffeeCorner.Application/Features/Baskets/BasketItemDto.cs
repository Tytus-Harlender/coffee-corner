namespace CoffeeCorner.Application.Features.Baskets;

public record BasketItemDto
{
    public Guid ProductPublicId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}