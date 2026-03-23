using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Orders.Application.Queries.GetAllCustomerOrders;

public class GetAllCustomerOrdersHandler(ICustomersModule customersModule, IOrderRepository orderRepository) : IRequestHandler<GetAllCustomerOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetAllCustomerOrdersQuery request, CancellationToken cancellationToken)
    {
        var customerId = await customersModule.GetCustomerDbIdAsync(request.UserPublicId);
        
        var orders = await orderRepository.GetAllUserOrdersAsync(customerId);

        return [.. orders.Select(o => new OrderDto() { Status = o.Status, TotalAmount = o.TotalAmount })];
    }
}