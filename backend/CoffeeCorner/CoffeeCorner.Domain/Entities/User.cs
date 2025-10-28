namespace CoffeeCorner.Domain.Entities;

public class User : BaseEntity
{
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<Basket> Baskets { get; set; } = [];
}
