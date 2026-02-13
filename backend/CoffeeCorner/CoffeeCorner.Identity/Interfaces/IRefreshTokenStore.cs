namespace CoffeeCorner.Identity.Interfaces;

public interface IRefreshTokenStore
{
    Task StoreAsync(string userId, string refreshToken, DateTime expiresAt, CancellationToken ct);
    Task<bool> ValidateAsync(string userId, string refreshToken, CancellationToken ct);
    Task RevokeAsync(string userId, string refreshToken, CancellationToken ct);
}