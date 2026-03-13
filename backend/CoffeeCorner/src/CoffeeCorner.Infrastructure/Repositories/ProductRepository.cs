using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class ProductRepository(CoffeeCornerDbContext dbContext) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetProductAsync(Guid publicId)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PublicId == publicId);

        return product ?? throw new Exception("Product not found");
    }

    public async Task<Dictionary<int, Guid>> GetProductsPublicIdsAsync(IEnumerable<int> productIds)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(p => productIds.Contains(p.Id))
            .ToDictionaryAsync(p => p.Id, p => p.PublicId);
    }

    public async Task<Dictionary<Guid, Product>> GetProductsByPublicIdsAsync(IEnumerable<Guid> publicIds)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(p => publicIds.Contains(p.PublicId))
            .ToDictionaryAsync(p => p.PublicId, p => p);
    }
}
