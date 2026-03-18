using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using MediatR;

namespace CoffeeCorner.Catalog.Application.Queries.GetAllProducts;

public class GetAllProductsHandler(ICatalogRepository catalogsRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await catalogsRepository.GetAllProductsAsync();

        return [.. result.Select(p => new ProductDto() { PublicId = p.PublicId, Name = p.Name, Description = p.Description })];
    }
}