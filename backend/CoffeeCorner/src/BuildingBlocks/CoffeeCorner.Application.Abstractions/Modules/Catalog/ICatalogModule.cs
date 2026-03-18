namespace CoffeeCorner.Application.Abstractions.Modules.Catalog;

public interface ICatalogModule
{
    public Task<Guid> GetProductPublicId(int productId);
    public Task<IDictionary<Guid, int>> GetProductDbIdsAsync(IEnumerable<Guid> publicProductIds);
    public Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    public Task<ProductDto> GetProductAsync(Guid publicId);
    public Task<Dictionary<int,Guid>> GetProductsPublicIdsAsync(IEnumerable<int> productIds);
    public Task<Dictionary<Guid, ProductDto>> GetProductsByPublicIdsAsync(IEnumerable<Guid> publicIds);
}