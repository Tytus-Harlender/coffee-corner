using CoffeeCorner.Application.Features.Orders;
using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetAllUserOrders;

public class GetAllUserOrdersHandler(IUserRepository userRepository) : IRequestHandler<GetAllUserOrdersQuery, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> Handle(GetAllUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await userRepository.GetAllUserOrdersAsync(request.UserPublicId);

        return [.. orders.Select(o => new OrderDto() { Status = o.Status, TotalAmount = o.TotalAmount })];
    }
}
