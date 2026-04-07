using CoffeeCorner.Orders;
using CoffeeCorner.Orders.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/users")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    [HttpPost("/from-basket/{customerPublicId:guid}")]
    [Authorize]
    public async Task<ActionResult<OrderDto>> CreateOrderFromBasket([FromRoute] Guid customerPublicId)
    {
        var orderDto = await mediator.Send( new CreateOrderFromBasketCommand(customerPublicId));

        return CreatedAtAction(nameof(CreateOrderFromBasket), orderDto);
    }
}
