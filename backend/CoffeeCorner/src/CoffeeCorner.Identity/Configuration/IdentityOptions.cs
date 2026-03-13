namespace CoffeeCorner.Identity.Configuration;


public sealed record IdentityOptions
{
    public string JwtIssuer { get; init; } = "CoffeeCorner";
    public string JwtAudience { get; init; } = "CoffeeCornerClient"!;
    public string JwtKey { get; init; } = "84dfe541a832ce0375bf6a3ee72c8636";
    public int AccessTokenMinutes { get; init; } = 15;
    public int RefreshTokenDays { get; init; } = 7;
}