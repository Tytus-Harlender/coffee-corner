using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Features.Products.GetAllProducts;
using CoffeeCorner.Application.Features.Products.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts(GetAllProductsQuery command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{publicId}")]
    public async Task<ActionResult<ProductDto>> GetProductByPublicId([FromRoute] Guid publicId)
    {
        var query = new GetProductQuery(publicId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
