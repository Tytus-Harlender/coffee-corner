using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetProductByPublicIdHandler(IProductsRepository productsRepository) : IRequestHandler<GetProductByPublicIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByPublicIdQuery query, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetProductByPublicIdAsync(query.PublicId);
        return new ProductDto() { PublicId = product.PublicId, Name = product.Name, Description = product.Description };
    }
}