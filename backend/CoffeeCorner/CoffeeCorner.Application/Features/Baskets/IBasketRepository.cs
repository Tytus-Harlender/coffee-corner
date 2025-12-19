using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Baskets;

public interface IBasketRepository
{
    public Task<Basket> GetUserBasketAsync(Guid userPublicId, bool asNoTracking = true);
    public Task AddBasketAsync(Basket basket);
    public Task UpdateBasketAsync(Basket basket);
    public Task DeleteBasketItemAsync(Basket basket, Guid productPublicId);
    public Task DeleteBasketAsync(Basket basket);
}
