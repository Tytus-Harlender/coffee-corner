using CoffeeCorner.Application.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<object> GetAllProducts(GetAllProductsQuery command)
    {
        var result = await _mediator.Send(command);
        return result;
    }

    [HttpGet("{publicId}")]
    public async Task<object> GetAllProducts([FromRoute] Guid publicId)
    {
        var query = new GetProductByIdQuery(publicId);
        var result = await _mediator.Send(query);
        return result;
    }
}
