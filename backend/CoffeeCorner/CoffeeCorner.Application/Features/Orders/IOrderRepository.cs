using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Orders;

public interface IOrderRepository
{
    public Task AddAsync(Order order);
}
