using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Baskets.AddUserBasketItems;
using CoffeeCorner.Application.Features.Baskets.GetUserBasket;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/users")]
public class BasketsController(IMediator mediator) : Controller
{
    [HttpGet("{publicId:guid}/basket")]
    public async Task<ActionResult<BasketDto>> GetUserBasketAsync([FromRoute] Guid publicId)
    {
        var query = new GetUserBasketQuery(publicId);
        var result = await mediator.Send(query);
        return result is null ? NotFound("Basket not found for the user") : Ok(result);
    }

    [HttpPost("{publicId:guid}/basket/items")]
    public async Task<ActionResult<BasketDto>> CreateUserBasketItemsAsync(AddUserBasketItemsCommand addUserBasketItemsCommand, [FromRoute] Guid publicId)
    {
        addUserBasketItemsCommand.UserPublicId = publicId;
        var result = await mediator.Send(addUserBasketItemsCommand);
        return result is null ? NotFound("Basket not found for the user") : Ok(result);
    }
}
