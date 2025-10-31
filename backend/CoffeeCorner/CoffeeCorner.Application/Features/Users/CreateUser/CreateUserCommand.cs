using MediatR;

namespace CoffeeCorner.Application.Features.Users.CreateUser;

public class CreateUserCommand : IRequest<UserDto>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Password { get; set; }
}
