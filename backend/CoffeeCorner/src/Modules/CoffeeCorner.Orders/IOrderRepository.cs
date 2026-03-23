using CoffeeCorner.Orders.Domain.Entities;

namespace CoffeeCorner.Orders;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllUserOrdersAsync(int customerId);
    public Task AddAsync(Order order);
}