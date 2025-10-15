using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Products;

public interface IProductsReadRepository
{
    public Task<List<Product>> GetAllProductsAsync();
}