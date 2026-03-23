namespace CoffeeCorner.Application.Abstractions.Modules.Customers;

public record CustomerDto
{
    public required Guid PublicId { get; init; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
}