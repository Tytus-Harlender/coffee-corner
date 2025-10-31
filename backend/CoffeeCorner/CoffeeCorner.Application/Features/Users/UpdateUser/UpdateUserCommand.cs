using MediatR;

namespace CoffeeCorner.Application.Features.Users.UpdateUser;

public class UpdateUserCommand : IRequest<UserDto>
{
    public required Guid PublicId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
