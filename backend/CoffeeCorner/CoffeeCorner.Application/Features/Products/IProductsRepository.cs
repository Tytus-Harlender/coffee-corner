using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Products;

public interface IProductsRepository
{
    public Task<List<Product>> GetAllProductsAsync();
    public Task<Product> GetProductByIdAsync(Guid publicId);
}