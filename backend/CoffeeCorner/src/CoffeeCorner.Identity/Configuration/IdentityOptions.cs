namespace CoffeeCorner.Identity.Configuration;


public sealed record IdentityOptions
{
    public string JwtIssuer { get; init; } = null!;
    public string JwtAudience { get; init; } = null!;
    public string JwtKey { get; init; } = null!;
    public int AccessTokenMinutes { get; init; } = 15;
    public int RefreshTokenDays { get; init; } = 7;
}