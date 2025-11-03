using CoffeeCorner.Application.Features.Orders;
using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetAllUserOrders;

public class GetAllUserOrdersQuery(Guid userPublicId) : IRequest<IEnumerable<OrderDto>>
{
    public Guid UserPublicId { get; set; } = userPublicId;
}
