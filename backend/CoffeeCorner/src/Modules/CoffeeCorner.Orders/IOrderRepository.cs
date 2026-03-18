using CoffeeCorner.Orders.Domain.Entities;

namespace CoffeeCorner.Orders;

public interface IOrderRepository
{
    public Task AddAsync(Order order);
}