using MediatR;

namespace CoffeeCorner.Application.Features.Authentication.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? AddressLine1 { get; set; }
}
