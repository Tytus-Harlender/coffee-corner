namespace CoffeeCorner.Basket;

public interface IBasketRepository
{
    public Task<Domain.Entities.Basket> GetBasketAsync(int customerId, bool asNoTracking = true);
    public Task AddBasketAsync(Domain.Entities.Basket basket);
    public Task UpdateBasketAsync(Domain.Entities.Basket basket);
    public Task DeleteBasketItemAsync(Domain.Entities.Basket basket, Guid productPublicId);
    public void DeleteBasket(Domain.Entities.Basket basket);
}