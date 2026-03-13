using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class BasketRepository(CoffeeCornerDbContext context) : IBasketRepository
{
    public async Task AddBasketAsync(Basket basket)
    {
        await context.Baskets.AddAsync(basket);
    }

    public Task UpdateBasketAsync(Basket basket)
    {
        context.Baskets.Update(basket);
        return Task.CompletedTask;
    }

    public async Task<Basket> GetBasketAsync(Guid customerPublicId, bool asNoTracking)
    {
        var customer = await context.Customers
            .FirstOrDefaultAsync(u => u.PublicId == customerPublicId);

        if (customer is null)
            throw new Exception($"{nameof(customer)} is null");

        IQueryable<Basket> query = context.Baskets
            .Where(b => b.CustomerId == customer.Id && !b.IsDeleted)
            .Include(b => b.BasketItems.Where(bi => bi.Quantity > 0))
                .ThenInclude(bi => bi.Product);

        if (asNoTracking)
            query = query.AsNoTracking();
            
        var existingBasket = await query.FirstOrDefaultAsync();

        if (existingBasket is not null)
            return existingBasket;

        var newBasket = new Basket()
        {
            CustomerId = customer.Id
        };

        await context.Baskets.AddAsync(newBasket);

        return newBasket;
    }

    public async Task DeleteBasketItemAsync(Basket basket, Guid productPublicId)
    {
        await context.BasketItems
            .Where(bi => bi.BasketId == basket.Id && bi.Product.PublicId == productPublicId)
            .ForEachAsync(bi => bi.IsDeleted = true);
    }

    public void DeleteBasket(Basket basket)
    {
        basket.IsDeleted = true;

        context.Baskets.Update(basket);
    }
}