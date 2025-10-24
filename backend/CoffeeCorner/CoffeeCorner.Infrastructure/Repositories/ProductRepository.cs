using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class ProductRepository(CoffeeCornerDbContext dbContext) : IProductsRepository
{
    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetProductByIdAsync(Guid publicId)
    {
        var product = await dbContext.Products.Where(p => p.PublicId == publicId).FirstOrDefaultAsync();

        return product is null ? throw new Exception("Product with given id does not exist") : product;
    }
}
