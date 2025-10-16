using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Infrastructure.Repositories;

public class ProductReadRepository : IProductsReadRepository
{
    public Task<List<Product>> GetAllProductsAsync()
    {
        return Task.FromResult(new List<Product>() { new() { Id = 1, PublicId = Guid.NewGuid(), Description = "Coffee beans of a great taste!", Name = "Golden Brew", Price = 39.99} });
    }
}
