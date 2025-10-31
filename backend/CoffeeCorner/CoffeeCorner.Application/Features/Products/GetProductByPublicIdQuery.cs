using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetProductByPublicIdQuery(Guid id) : IRequest<ProductDto>
{
    public Guid PublicId { get; set; } = id;
}