using CoffeeCorner.Application.Features.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetUserById), new { publicId = result.PublicId }, result);
    }

    [HttpGet("{publicId:guid}")]
    public async Task<ActionResult<UserDto>> GetUserById([FromRoute] Guid publicId)
    {
        var query = new GetUserByPublicIdQuery(publicId);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
