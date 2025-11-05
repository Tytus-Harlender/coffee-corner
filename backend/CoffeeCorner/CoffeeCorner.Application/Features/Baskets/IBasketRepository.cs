using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Baskets;

public interface IBasketRepository
{
    public Task<Basket> GetUserBasketAsync(Guid publicId, bool asNoTracking = true);
    public Task AddAsync(Basket basket);
    public Task Update(Basket basket);
}
