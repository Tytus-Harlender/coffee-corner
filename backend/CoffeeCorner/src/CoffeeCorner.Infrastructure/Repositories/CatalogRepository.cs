using CoffeeCorner.Catalog.Application;
using CoffeeCorner.Catalog.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class CatalogRepository(CoffeeCornerDbContext dbContext) : ICatalogRepository
{
    public async Task<int> GetProductDbIdAsync(Guid productPublicId)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(p => p.PublicId == productPublicId)
            .Select(p => p.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<Guid> GetProductPublicIdAsync(int productId)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(p => p.Id == productId)
            .Select(p => p.PublicId)
            .FirstOrDefaultAsync();
    }

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
    
    public async Task<IDictionary<Guid,int>> GetProductsDbIdsAsync(IEnumerable<Guid> publicProductIds)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(p => publicProductIds.Contains(p.PublicId))
            .ToDictionaryAsync(p => p.PublicId, p => p.Id);
    }

    public async Task<Dictionary<Guid, Product>> GetProductsByPublicIdsAsync(IEnumerable<Guid> publicIds)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(p => publicIds.Contains(p.PublicId))
            .ToDictionaryAsync(p => p.PublicId, p => p);
    }
}
