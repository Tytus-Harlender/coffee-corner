using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeCorner.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/")]
public class AuthenticationController(IIdentityService identityService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await identityService.RegisterAsync(request, CancellationToken.None);
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
