namespace CoffeeCorner.Basket.Application;

public record BasketItemDto
{
    public Guid ProductPublicId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}