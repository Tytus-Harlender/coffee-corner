namespace CoffeeCorner.Application.Features.Users;

public class CustomerDto
{
    public required Guid PublicId { get; init; }
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
}
