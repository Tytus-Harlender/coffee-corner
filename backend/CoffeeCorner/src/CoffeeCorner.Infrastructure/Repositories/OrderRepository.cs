using CoffeeCorner.Infrastructure.Persistence;
using CoffeeCorner.Orders;
using CoffeeCorner.Orders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class OrderRepository(CoffeeCornerDbContext dbContext) : IOrderRepository
{
    public async Task<IEnumerable<Order>> GetAllUserOrdersAsync(int customerId)
    {
        var userOrders = await dbContext.Orders
            .AsNoTracking()
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();

    if (userOrders.Count == 0)
            throw new Exception("No orders found for the user");

        return userOrders;
    }

    public async Task AddAsync(Order order)
    {
        await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
    }
}