using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetProductByIdQuery(Guid id) : IRequest<ProductDto>
{
    public Guid PublicId { get; set; } = id;
}