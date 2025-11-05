using CoffeeCorner.Application.Features.Orders;
using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Application.Features.Users.CreateUser;
using CoffeeCorner.Application.Features.Users.DeleteUser;
using CoffeeCorner.Application.Features.Users.GetAllUserOrders;
using CoffeeCorner.Application.Features.Users.GetAllUsers;
using CoffeeCorner.Application.Features.Users.GetUser;
using CoffeeCorner.Application.Features.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(GetAllUsersQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{publicId:guid}")]
    public async Task<ActionResult<UserDto>> GetUserAsync([FromRoute] Guid publicId)
    {
        var query = new GetUserQuery(publicId);
        var result = await mediator.Send(query);
        return result is null ? NotFound("User not found") : Ok(result);
    }

    [HttpGet("{publicId:guid}/orders")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllUserOrdersAsync([FromRoute] Guid publicId)
    {
        var query = new GetAllUserOrdersQuery(publicId);
        var result = await mediator.Send(query);
        return result is null ? NotFound("Orders not found for the user") : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUserAsync), new { publicId = result.PublicId }, result);
    }

    [HttpPut("{publicId:guid}")]
    public async Task<ActionResult> UpdateUserAsync(UpdateUserCommand command, [FromRoute] Guid publicId)
    {
        command.PublicId  = publicId;
        var result = await mediator.Send(command);
        return result is null ? BadRequest() : Ok(result);
    }

    [HttpDelete("{publicId:guid}")]
    public async Task<ActionResult> DeleteUserAsync([FromRoute] Guid publicId)
    {
        var command = new DeleteUserCommand(publicId);
        var result = await mediator.Send(command);
        return result is null ? BadRequest() : NoContent();
    }
}
