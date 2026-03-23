using MediatR;

namespace CoffeeCorner.Orders.Application.Queries.GetAllCustomerOrders;

public class GetAllCustomerOrdersQuery(Guid userPublicId) : IRequest<IEnumerable<OrderDto>>
{
    public Guid UserPublicId { get; set; } = userPublicId;
}