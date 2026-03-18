using MediatR;

namespace CoffeeCorner.Orders.Application.Commands;

public class CreateOrderFromBasketCommand(Guid customerPublicId) : IRequest<OrderDto>
{
    public Guid CustomerPublicId { get; private set; } = customerPublicId;
}