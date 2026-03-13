using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Products;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product> GetProductAsync(Guid publicId);
    public Task<Dictionary<int,Guid>> GetProductsPublicIdsAsync(IEnumerable<int> productIds);
    public Task<Dictionary<Guid, Product>> GetProductsByPublicIdsAsync(IEnumerable<Guid> publicIds);
}