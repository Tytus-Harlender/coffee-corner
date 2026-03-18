using CoffeeCorner.Basket.Application;

namespace CoffeeCorner.Application.Abstractions.Modules.Basket;

public record BasketDto
{
    public Guid CustomerPublicId { get; set; }
    public IEnumerable<BasketItemDto> BasketItems { get; set; } = [];
}