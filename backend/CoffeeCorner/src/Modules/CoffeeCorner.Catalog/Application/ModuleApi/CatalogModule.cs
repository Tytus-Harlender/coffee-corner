using CoffeeCorner.Application.Abstractions.Modules.Catalog;

namespace CoffeeCorner.Catalog.Application.ModuleApi;

public class CatalogModule(
    ICatalogRepository catalogRepository)
    : ICatalogModule
{
    public async Task<Guid> GetProductPublicId(int productId)
    {
        return await catalogRepository
            .GetProductPublicIdAsync(productId);
    }

    public async Task<IDictionary<Guid,int>> GetProductDbIdsAsync(IEnumerable<Guid> publicProductIds)
    {
        return await catalogRepository
            .GetProductsDbIdsAsync(publicProductIds);
    }

    //not implemented
    public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductDto> GetProductAsync(Guid publicId)
    {
        var product = await catalogRepository
            .GetProductAsync(publicId);

        return new ProductDto()
        {
            PublicId = publicId,
            Name = product.Name,
            Description = product.Description
        };
    }

    public async Task<Dictionary<int, Guid>> GetProductsPublicIdsAsync(
        IEnumerable<int> productIds)
    {
        return await catalogRepository
            .GetProductsPublicIdsAsync(productIds);
    }

    public async Task<Dictionary<Guid, ProductDto>> GetProductsByPublicIdsAsync(IEnumerable<Guid> publicIds)
    {
        var productsDictionary = await catalogRepository
            .GetProductsByPublicIdsAsync(publicIds);

        var productDtos = new Dictionary<Guid, ProductDto>();

        foreach (var (publicId, product) in productsDictionary)
        {
            productDtos.Add(publicId, new ProductDto()
            {
                PublicId = publicId,
                Name = product.Name,
                Description = product.Description
            });
        }
        
        return  productDtos;
    }
}