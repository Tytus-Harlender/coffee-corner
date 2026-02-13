using CoffeeCorner.Identity.Helpers;
using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Interfaces.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityOptions = CoffeeCorner.Identity.Configuration.IdentityOptions;

namespace CoffeeCorner.Identity.Services;

public class IdentityService(
    UserManager<IdentityUser> userManager,
    ITokenService tokenService,
    IRefreshTokenStore refreshStore,
    IdentityOptions options) : IIdentityService
{
    public async Task<TokenResult> RegisterAsync(RegisterRequest request, CancellationToken ct)
    {
        var user = new IdentityUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new Exception("Registration failed.");

        return await GenerateTokenAsync(user, ct);
    }

    public async Task<TokenResult> LoginAsync(LoginRequest request, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(request.Email)
                   ?? throw new Exception("Invalid credentials.");

        if (!await userManager.CheckPasswordAsync(user, request.Password))
            throw new Exception("Invalid credentials.");

        return await GenerateTokenAsync(user, ct);
    }

    public async Task<TokenResult> RefreshAsync(RefreshTokenRequest request, CancellationToken ct)
    {
        var principal = JwtHelper.GetPrincipalFromExpiredToken(request.AccessToken, options);

        var userId = principal.FindFirst("sub")!.Value;

        var valid = await refreshStore.ValidateAsync(userId, request.RefreshToken, ct);
        if (!valid)
            throw new Exception("Invalid refresh token.");

        var user = await userManager.FindByIdAsync(userId)
                   ?? throw new Exception("User not found.");

        return await GenerateTokenAsync(user, ct);
    }

    public async Task<bool> DeleteUserAsync(Guid publicUserId, CancellationToken ct)
    {
        var user = await userManager.Users
            .FirstOrDefaultAsync(x => x.Id == publicUserId.ToString(), ct);

        if (user is null)
            return false;

        await userManager.DeleteAsync(user);
        return true;
    }

    private async Task<TokenResult> GenerateTokenAsync(IdentityUser user, CancellationToken ct)
    {
        var roles = await userManager.GetRolesAsync(user);

        return await tokenService.GenerateTokensAsync(
            user.Id,
            Guid.Parse(user.Id),
            user.Email!,
            roles,
            ct);
    }
}