using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetProductByIdHandler(IProductsRepository productsRepository) : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await productsRepository.GetProductByIdAsync(query.PublicId);
        return new ProductDto() { PublicId = product.PublicId, Name = product.Name, Description = product.Description };
    }
}