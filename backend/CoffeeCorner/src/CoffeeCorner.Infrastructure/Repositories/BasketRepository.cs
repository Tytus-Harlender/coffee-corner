using CoffeeCorner.Basket;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class BasketRepository(CoffeeCornerDbContext context) : IBasketRepository
{
    public async Task AddBasketAsync(Basket.Domain.Entities.Basket basket)
    {
        await context.Baskets.AddAsync(basket);
        await context.SaveChangesAsync();
    }

    public async Task UpdateBasketAsync(Basket.Domain.Entities.Basket basket)
    {
        context.Baskets.Update(basket);
        await context.SaveChangesAsync();
    }

    public async Task<Basket.Domain.Entities.Basket> GetBasketAsync(int customerId, bool asNoTracking)
    {
        if (customerId == 0)
            throw new Exception($"Customer internal Id cannot be set to 0");

        IQueryable<Basket.Domain.Entities.Basket> query = context.Baskets
            .Where(b => b.CustomerId == customerId && !b.IsDeleted)
            .Include(b => b.BasketItems);

        if (asNoTracking)
            query = query.AsNoTracking();
            
        var existingBasket = await query.FirstOrDefaultAsync();

        if (existingBasket is not null)
            return existingBasket;

        var newBasket = new Basket.Domain.Entities.Basket()
        {
            CustomerId = customerId
        };

        await context.Baskets.AddAsync(newBasket);

        return newBasket;
    }

    public async Task DeleteBasketItemAsync(Basket.Domain.Entities.Basket basket, Guid productPublicId)
    {
        var product = context.Products.FirstOrDefault(p => p.PublicId == productPublicId);
        
        if (product is null)
            throw new Exception($"{nameof(product)} is null");
        
        await context.BasketItems
            .Where(bi => bi.BasketId == basket.Id && bi.ProductId == product.Id)
            .ForEachAsync(bi => bi.IsDeleted = true);

        await context.SaveChangesAsync();
    }

    public async Task DeleteBasket(Basket.Domain.Entities.Basket basket)
    {
        basket.IsDeleted = true;

        context.Baskets.Update(basket);
        await context.SaveChangesAsync();
    }

    public async Task ClearBasketAsync(Basket.Domain.Entities.Basket basket)
    {
        basket.BasketItems.Clear();
        await context.SaveChangesAsync();
    }
}