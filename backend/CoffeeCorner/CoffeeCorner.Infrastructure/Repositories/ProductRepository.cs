using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class ProductRepository(CoffeeCornerDbContext dbContext) : IProductsRepository
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

        return product is null ? new Product() : product;
    }
}
