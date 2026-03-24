using CoffeeCorner.Customers.Domain.Exceptions;
using CoffeeCorner.Orders.Domain.Entities;
using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Customers.Domain.Entities;

public sealed class Customer : BaseEntity
{
    public Guid PublicId { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Surname { get; private set; } = string.Empty;
    public string? AddressLine1 { get; private set; }
    public string? AddressLine2 { get; private set; }
    public string? City { get; private set; }
    public string? Country { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; }

    private Customer()
    {
    }

    public Customer(
        Guid publicId,
        string name,
        string surname,
        string email,
        string? addressLine1 = null,
        string? addressLine2 = null,
        string? city = null,
        string? country = null,
        string? phoneNumber = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CustomerCreationException("Customers name cannot be null or empty");

        if (string.IsNullOrWhiteSpace(surname))
            throw new CustomerCreationException("Customers surname must be positive");
        
        if (string.IsNullOrWhiteSpace(email))
            throw new CustomerCreationException("Email is required");

        PublicId = publicId;
        Name = name;
        Surname = surname;
        Email = email;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Country = country;
        PhoneNumber = phoneNumber;
    }
}