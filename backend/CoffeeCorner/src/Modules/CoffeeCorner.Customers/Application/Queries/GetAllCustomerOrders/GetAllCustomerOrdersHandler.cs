using CoffeeCorner.Orders;
using MediatR;

namespace CoffeeCorner.Customers.Application.Queries.GetAllCustomerOrders;

public class GetAllCustomerOrdersHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomerOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetAllCustomerOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await customerRepository.GetAllUserOrdersAsync(request.UserPublicId);

        return [.. orders.Select(o => new OrderDto() { Status = o.Status, TotalAmount = o.TotalAmount })];
    }
}