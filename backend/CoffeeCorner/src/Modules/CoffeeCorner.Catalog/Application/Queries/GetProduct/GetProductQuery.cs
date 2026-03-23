using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using MediatR;

namespace CoffeeCorner.Catalog.Application.Queries.GetProduct;

public class GetProductQuery(Guid id) : IRequest<ProductDto>
{
    public Guid PublicId { get; set; } = id;
}