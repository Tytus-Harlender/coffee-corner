using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Baskets;

public interface IBasketRepository
{
    public Task<Basket> GetUserBasketAsync(Guid publicId);
    public Task<IEnumerable<BasketItem>> AddUserBasketItemsAsync(IEnumerable<BasketItem> basketItems);
}
