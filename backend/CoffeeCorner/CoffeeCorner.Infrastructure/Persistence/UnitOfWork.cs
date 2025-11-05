using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Interfaces;

namespace CoffeeCorner.Infrastructure.Persistence;

public class UnitOfWork(CoffeeCornerDbContext context, IBasketRepository basketRepository) : IUnitOfWork
{
    private readonly CoffeeCornerDbContext _context = context;
    public IBasketRepository BasketRepository { get; } = basketRepository;

    public void Dispose() => _context.Dispose();

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
