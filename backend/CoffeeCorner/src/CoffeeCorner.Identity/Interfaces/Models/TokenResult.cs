namespace CoffeeCorner.Identity.Interfaces.Models;

public sealed record TokenResult(
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiresAt,
    Guid PublicId);