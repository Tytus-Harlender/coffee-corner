using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class ProductReadRepository(CoffeeCornerDbContext dbContext) : IProductsReadRepository
{
    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }
}
