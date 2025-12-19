using MediatR;

namespace CoffeeCorner.Application.Features.Orders.CreateOrderFromBasket;

public class CreateOrderFromBasketCommand(Guid basketPublicId) : IRequest<OrderDto>
{
    public Guid BasketPublicId { get; private set; } = basketPublicId;
}