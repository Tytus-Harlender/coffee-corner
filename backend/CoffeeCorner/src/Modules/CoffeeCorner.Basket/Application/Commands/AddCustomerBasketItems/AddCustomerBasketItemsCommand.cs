using MediatR;

namespace CoffeeCorner.Basket.Application.Commands.AddCustomerBasketItems;

public class AddCustomerBasketItemsCommand(Guid userPublicId) : IRequest<IEnumerable<BasketItemDto>>
{
    public Guid UserPublicId { get; set; } = userPublicId;
    public IEnumerable<BasketItemDto> Items { get; set; } = [];
}
