using MediatR;

namespace CoffeeCorner.Application.Features.Authentication.AuthenticateUser;

public class AuthenticateUserCommand : IRequest<string>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
