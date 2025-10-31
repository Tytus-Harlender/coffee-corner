using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Products;

public interface IProductsRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product> GetProductAsync(Guid publicId);
}