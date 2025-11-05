using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.AddUserBasketItems;

public class AddUserBasketItemsCommand(Guid userPublicId) : IRequest<IEnumerable<BasketItemDto>>
{
    public Guid UserPublicId { get; set; } = userPublicId;
    public IEnumerable<BasketItemDto> Items { get; set; } = [];
}
