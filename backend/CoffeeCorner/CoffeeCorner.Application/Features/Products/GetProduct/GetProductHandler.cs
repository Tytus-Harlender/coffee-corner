using MediatR;

namespace CoffeeCorner.Application.Features.Products.GetProduct;

public class GetProductHandler(IProductsRepository productsRepository) : IRequestHandler<GetProductQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetProductAsync(query.PublicId);
        return new ProductDto() { PublicId = product.PublicId, Name = product.Name, Description = product.Description };
    }
}