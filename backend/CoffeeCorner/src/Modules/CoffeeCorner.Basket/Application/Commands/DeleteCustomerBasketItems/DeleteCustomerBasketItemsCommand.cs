using MediatR;

namespace CoffeeCorner.Basket.Application.Commands.DeleteCustomerBasketItems;

public class DeleteCustomerBasketItemsCommand(Guid userPublicId, Guid productPublicId) : IRequest<Unit>
{
    public Guid UserPublicId { get; } = userPublicId;
    public Guid ProductPublicId { get; } = productPublicId;
}