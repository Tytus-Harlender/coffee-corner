namespace CoffeeCorner.Identity.Persistence.Entities;

public class RefreshToken
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
}