using CoffeeCorner.Identity.Interfaces.Models;
using MediatR;

namespace CoffeeCorner.Application.Accounts;

public record RegisterUserCommand : IRequest<TokenResult>
{
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}