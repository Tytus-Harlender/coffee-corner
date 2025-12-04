using Microsoft.AspNetCore.Identity;

namespace CoffeeCorner.Domain.Entities;

public class User : IdentityUser<int>
{
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<Basket> Baskets { get; set; } = [];
}
