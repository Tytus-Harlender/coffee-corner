using CoffeeCorner.Orders;
using MediatR;

namespace CoffeeCorner.Customers.Application.Queries.GetAllCustomerOrders;

public class GetAllCustomerOrdersQuery(Guid userPublicId) : IRequest<IEnumerable<OrderDto>>
{
    public Guid UserPublicId { get; set; } = userPublicId;
}