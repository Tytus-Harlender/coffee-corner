using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using MediatR;

namespace CoffeeCorner.Catalog.Application.Queries.GetProduct;

public class GetProductHandler(ICatalogRepository catalogsRepository) : IRequestHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = await catalogsRepository.GetProductAsync(query.PublicId);
        return new ProductDto() { PublicId = product.PublicId, Name = product.Name, Description = product.Description };
    }
}