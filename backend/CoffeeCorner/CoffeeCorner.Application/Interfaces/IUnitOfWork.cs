using CoffeeCorner.Application.Features.Baskets;

namespace CoffeeCorner.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBasketRepository BasketRepository { get; }
    Task SaveChangesAsync();
}
