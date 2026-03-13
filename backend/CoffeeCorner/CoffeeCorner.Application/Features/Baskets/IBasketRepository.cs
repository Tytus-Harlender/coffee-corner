using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Baskets;

public interface IBasketRepository
{
    public Task<Basket> GetBasketAsync(Guid customerPublicId, bool asNoTracking = true);
    public Task AddBasketAsync(Basket basket);
    public Task UpdateBasketAsync(Basket basket);
    public Task DeleteBasketItemAsync(Basket basket, Guid productPublicId);
    public void DeleteBasket(Basket basket);
}
