using CoffeeCorner.Infrastructure.Persistence;
using CoffeeCorner.Orders;
using CoffeeCorner.Orders.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Repositories;

public class OrderRepository(CoffeeCornerDbContext dbContext) : IOrderRepository
{
    public async Task AddAsync(Order order)
    {
        await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
    }
}
