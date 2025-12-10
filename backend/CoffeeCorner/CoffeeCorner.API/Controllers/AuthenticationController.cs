using CoffeeCorner.Application.Features.Authentication.AuthenticateUser;
using CoffeeCorner.Application.Features.Authentication.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/")]
public class AuthenticationController(IMediator mediator) : ControllerBase
{

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(AuthenticateUserCommand command)
    {
        var token = await mediator.Send(command);

        if (token == null)
            return Unauthorized();

        return Ok(new { token });
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(new { userId = id });
    }
}
