using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Baskets.AddUserBasketItems;
using CoffeeCorner.Application.Features.Baskets.DeleteUserBasketItems;
using CoffeeCorner.Application.Features.Baskets.GetUserBasket;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/users")]
public class BasketsController(IMediator mediator) : ControllerBase
{
    [HttpGet("{publicId:guid}/basket")]
    [Authorize]
    [ProducesResponseType(typeof(BasketDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BasketDto>> GetUserBasketAsync([FromRoute] Guid publicId)
    {
        var query = new GetUserBasketQuery(publicId);
        var result = await mediator.Send(query);
        return result is null ? NotFound("Basket not found for the user") : Ok(result);
    }

    [HttpPost("{userPublicId:guid}/basket/items")]
    [Authorize]
    [ProducesResponseType(typeof(BasketDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BasketDto>> CreateUserBasketItemsAsync(AddUserBasketItemsCommand addUserBasketItemsCommand, [FromRoute] Guid userPublicId)
    {
        addUserBasketItemsCommand.UserPublicId = userPublicId;
        var result = await mediator.Send(addUserBasketItemsCommand);
        return result is null ? NotFound("Basket not found for the user") : Ok(result);
    }

    [HttpDelete("{userPublicId:guid}/basket/items/{productPublicId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<BasketDto>> DeleteUserBasketItemsAsync([FromRoute] Guid userPublicId, [FromRoute] Guid productPublicId)
    {
        var command = new DeleteUserBasketItemsCommand(userPublicId, productPublicId);
        _ = await mediator.Send(command);
        return NoContent();
    }
}
