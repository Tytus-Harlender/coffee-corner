using CoffeeCorner.Identity.Interfaces;
using CoffeeCorner.Identity.Persistence;
using CoffeeCorner.Identity.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Identity.Services;

public sealed class RefreshTokenStore(AuthDbContext context) : IRefreshTokenStore
{
    private readonly AuthDbContext _context = context;

    public async Task StoreAsync(string userId, string refreshToken, DateTime expiresAt, CancellationToken ct)
    {
        _context.RefreshTokens.Add(new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Token = refreshToken,
            ExpiresAt = expiresAt
        });

        await _context.SaveChangesAsync(ct);
    }

    public async Task<bool> ValidateAsync(string userId, string refreshToken, CancellationToken ct)
    {
        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.Token == refreshToken &&
                    !x.IsRevoked,
                ct);

        if (token is null || token.ExpiresAt < DateTime.UtcNow)
            return false;

        return true;
    }

    public async Task RevokeAsync(string userId, string refreshToken, CancellationToken ct)
    {
        var token = await _context.RefreshTokens
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Token == refreshToken, ct);

        if (token is null)
            return;

        token.IsRevoked = true;

        await _context.SaveChangesAsync(ct);
    }
}