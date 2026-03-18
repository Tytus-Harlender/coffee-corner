using CoffeeCorner.Catalog.Domain.Entities;

namespace CoffeeCorner.Catalog.Application;

public interface ICatalogRepository
{
    public Task<int> GetProductDbIdAsync(Guid productPublicId);
    public Task<Guid> GetProductPublicIdAsync(int productId);
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product> GetProductAsync(Guid publicId);
    public Task<Dictionary<int,Guid>> GetProductsPublicIdsAsync(IEnumerable<int> productIds);
    public Task<IDictionary<Guid, int>> GetProductsDbIdsAsync(IEnumerable<Guid> publicProductIds);
    public Task<Dictionary<Guid, Product>> GetProductsByPublicIdsAsync(IEnumerable<Guid> publicIds);
}