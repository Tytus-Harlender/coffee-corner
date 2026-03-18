using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using MediatR;

namespace CoffeeCorner.Catalog.Application.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{

}