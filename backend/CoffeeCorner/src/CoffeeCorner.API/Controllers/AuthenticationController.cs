using CoffeeCorner.Application.Accounts;
using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Interfaces.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/")]
public class AuthenticationController(IIdentityService identityService, IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<TokenResult>> Register(RegisterRequest request)
    {
        var registerUserCommand = new RegisterUserCommand()
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            Password = request.Password
        };
        var result = await mediator.Send(registerUserCommand, CancellationToken.None);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await identityService.LoginAsync(request, CancellationToken.None);
        return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenRequest request)
    {
        var result = await identityService.RefreshAsync(request, CancellationToken.None);
        return Ok(result);
    }
}
