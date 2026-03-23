using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoffeeCorner.Identity.Configuration;
using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Interfaces.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoffeeCorner.Identity.Services;

public sealed class TokenService(
    IOptions<IdentityOptions> options,
    IRefreshTokenStore refreshStore)
    : ITokenService
{
    private readonly IdentityOptions _options = options.Value;

    public async Task<TokenResult> GenerateTokensAsync(
        int userId,
        Guid publicUserId,
        string email,
        IList<string> roles,
        CancellationToken ct)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.JwtKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new("sub", userId.ToString()),
            new("email", email),
            new("publicId", publicUserId.ToString())
        };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var expires = DateTime.UtcNow.AddMinutes(_options.AccessTokenMinutes);

        var token = new JwtSecurityToken(
            _options.JwtIssuer,
            _options.JwtAudience,
            claims,
            expires: expires,
            signingCredentials: credentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        var refreshToken = Guid.NewGuid().ToString("N");

        await refreshStore.StoreAsync(
            userId.ToString(),
            refreshToken,
            DateTime.UtcNow.AddDays(_options.RefreshTokenDays),
            ct);

        return new TokenResult(accessToken, refreshToken, expires, publicUserId);
    }
}