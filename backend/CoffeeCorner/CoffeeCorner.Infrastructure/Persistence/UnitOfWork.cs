using System.Transactions;
using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoffeeCorner.Infrastructure.Persistence;

public class UnitOfWork(CoffeeCornerDbContext context, ICustomerRepository customerRepository, IBasketRepository basketRepository) : IUnitOfWork
{
    private IDbContextTransaction? _tx;
    
    public ICustomerRepository CustomerRepository { get; } = customerRepository;
    public IBasketRepository BasketRepository { get; } = basketRepository;

    
    public async Task BeginTransactionAsync(CancellationToken ct)
        => _tx = await context.Database.BeginTransactionAsync(ct);

    public async Task CommitTransactionAsync(CancellationToken ct)
        => await _tx!.CommitAsync(ct);

    public async Task RollbackTransactionAsync(CancellationToken ct)
        => await _tx!.RollbackAsync(ct);

    public Task SaveChangesAsync(CancellationToken ct)
        => context.SaveChangesAsync(ct);
    
    public void Dispose() => context.Dispose();
}