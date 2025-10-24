using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetAllProductsHandler(IProductsRepository productsRepository) : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await productsRepository.GetAllProductsAsync();
        return [.. result.Select(x => new ProductDto() { PublicId = x.PublicId, Name = x.Name, Description = x.Description })];
    }
}