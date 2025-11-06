using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.DeleteUserBasketItems;

public class DeleteUserBasketItemsCommand(Guid userPublicId, Guid productPublicId) : IRequest<Unit>
{
    public Guid UserPublicId { get; } = userPublicId;
    public Guid ProductPublicId { get; } = productPublicId;
}
