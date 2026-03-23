using CoffeeCorner.Identity.Interfaces.Models;

namespace CoffeeCorner.Identity.Interfaces;

public interface IIdentityService
{
    Task<TokenResult> RegisterAsync(RegisterRequest request, CancellationToken ct);
    Task<TokenResult> LoginAsync(LoginRequest request, CancellationToken ct);
    Task<TokenResult> RefreshAsync(RefreshTokenRequest request, CancellationToken ct);
    Task<bool> DeleteUserAsync(Guid publicUserId, CancellationToken ct);
}