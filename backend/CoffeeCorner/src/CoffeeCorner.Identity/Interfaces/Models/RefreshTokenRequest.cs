namespace CoffeeCorner.Identity.Interfaces.Models;

public record RefreshTokenRequest(
    string AccessToken,
    string RefreshToken);