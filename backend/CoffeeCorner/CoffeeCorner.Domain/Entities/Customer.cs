using CoffeeCorner.Domain.Exceptions;

namespace CoffeeCorner.Domain.Entities;

public sealed class Customer : BaseEntity
{
    public required Guid PublicId { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public ICollection<Order> Orders { get; private set; } = [];
    public ICollection<Basket> Baskets { get; private set; } = [];

    private Customer()
    {
    }

    public Customer(
        string name,
        string surname,
        string email,
        string? addressLine1 = null,
        string? addressLine2= null,
        string? city= null,
        string? country= null,
        string? phoneNumber= null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CustomerCreationException("Customers name cannot be null or empty");

        if (string.IsNullOrWhiteSpace(surname))
            throw new CustomerCreationException("Customers surname must be positive");
        
        Name = name;
        Surname = surname;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Country = country;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}