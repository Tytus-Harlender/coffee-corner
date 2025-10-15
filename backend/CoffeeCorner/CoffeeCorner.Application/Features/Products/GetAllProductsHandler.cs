using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetAllProductsHandler(IProductsReadRepository productsReadRepository) : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productsReadRepository.GetAllProductsAsync();
        return [.. result.Select(x => new ProductDto() { Name = x.Name, Description = x.Description })];
    }
}