using CoffeeCorner.Identity.Interfaces.Models;

namespace CoffeeCorner.Identity.Interfaces;

public interface ITokenService
{
    Task<TokenResult> GenerateTokensAsync(
        string userId,
        Guid publicUserId,
        string email,
        IList<string> roles,
        CancellationToken ct);
}