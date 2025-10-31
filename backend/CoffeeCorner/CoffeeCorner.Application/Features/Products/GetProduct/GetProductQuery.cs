using MediatR;

namespace CoffeeCorner.Application.Features.Products.GetProduct;

public class GetProductQuery(Guid id) : IRequest<ProductDto>
{
    public Guid PublicId { get; set; } = id;
}