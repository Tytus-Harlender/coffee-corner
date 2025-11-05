using MediatR;

namespace CoffeeCorner.Application.Features.Products.GetAllProducts;

public class GetAllProductsHandler(IProductRepository productsRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productsRepository.GetAllProductsAsync();

        return [.. result.Select(p => new ProductDto() { PublicId = p.PublicId, Name = p.Name, Description = p.Description })];
    }
}