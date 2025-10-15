using MediatR;

namespace CoffeeCorner.Application.Features.Products;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{

}