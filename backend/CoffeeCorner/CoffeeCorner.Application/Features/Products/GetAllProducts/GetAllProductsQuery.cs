using MediatR;

namespace CoffeeCorner.Application.Features.Products.GetAllProducts;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{

}