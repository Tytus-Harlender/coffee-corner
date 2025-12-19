using CoffeeCorner.Application.Features.Orders;
using CoffeeCorner.Application.Features.Orders.CreateOrderFromBasket;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/users")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost("/from-basket/{basketId:guid}")]
    [Authorize]
    public async Task<ActionResult<OrderDto>> CreateOrderFromBasket([FromRoute] Guid basketId)
    {
        var orderDto = await mediator.Send( new CreateOrderFromBasketCommand(basketId));

        return CreatedAtAction(nameof(CreateOrderFromBasket), orderDto);
    }
}
