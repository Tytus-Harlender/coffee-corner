

namespace CoffeeCorner.Application.Abstractions.Modules.Basket;

public interface IBasketModule
{
    Task<BasketDto?> GetBasketDataByCustomerIdAsync(Guid customerId, CancellationToken ct);

    Task ClearAsync(Guid customerId, CancellationToken ct);
}