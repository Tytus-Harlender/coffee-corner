using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class BasketRepository(CoffeeCornerDbContext context) : IBasketRepository
{
    public async Task<IEnumerable<BasketItem>> AddUserBasketItemsAsync(IEnumerable<BasketItem> basketItems)
    {
        await context.BasketItems.AddRangeAsync(basketItems);
        await context.SaveChangesAsync();
        return basketItems;
    }

    public async Task<Basket> GetUserBasketAsync(Guid userPublicId)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.PublicId == userPublicId);

        var existingBasket = await context.Baskets
            .AsNoTracking()
            .Where(b => b.User.PublicId == userPublicId && !b.IsDeleted)
            .Include(b => b.User)
            .Include(b => b.BasketItems)
            .FirstOrDefaultAsync();

        if (user is null)
            throw new Exception($"{nameof(user)} is null");
        else if (existingBasket is not null)
            return existingBasket;

        var newBasket = new Basket()
        {
            User = user,
        };

        await context.Baskets.AddAsync(newBasket);
        await context.SaveChangesAsync();

        return newBasket;
    }
}
