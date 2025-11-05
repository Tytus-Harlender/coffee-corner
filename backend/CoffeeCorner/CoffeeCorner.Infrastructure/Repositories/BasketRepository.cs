using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class BasketRepository(CoffeeCornerDbContext context) : IBasketRepository
{
    public async Task AddAsync(Basket basket)
    {
        await context.Baskets.AddAsync(basket);
    }

    public Task Update(Basket basket)
    {
        context.Baskets.Update(basket);
        return Task.CompletedTask;
    }

    public async Task<Basket> GetUserBasketAsync(Guid userPublicId, bool asNoTracking)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.PublicId == userPublicId);

        if (user is null)
            throw new Exception($"{nameof(user)} is null");

        var query = context.Baskets
            .Where(b => b.UserId == user.Id && !b.IsDeleted)
            .Include(b => b.BasketItems);

        if (asNoTracking)
            query.AsNoTracking();
            
        var existingBasket = await query.FirstOrDefaultAsync();

        if (existingBasket is not null)
            return existingBasket;

        var newBasket = new Basket()
        {
            UserId = user.Id
        };

        await context.Baskets.AddAsync(newBasket);

        return newBasket;
    }
}
