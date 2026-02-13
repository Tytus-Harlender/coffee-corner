using System.Transactions;
using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Users;

namespace CoffeeCorner.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository CustomerRepository { get; }
    IBasketRepository BasketRepository { get; }
    Task BeginTransactionAsync(CancellationToken ct);
    Task CommitTransactionAsync(CancellationToken ct);
    Task RollbackTransactionAsync(CancellationToken ct);

    Task SaveChangesAsync(CancellationToken ct);
}
