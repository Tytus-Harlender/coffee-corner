using CoffeeCorner.Application.Features.Orders;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;

namespace CoffeeCorner.Infrastructure.Repositories;

public class OrderRepository(CoffeeCornerDbContext dbContext) : IOrderRepository
{
    public async Task AddAsync(Order order)
    {
        await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
    }
}
