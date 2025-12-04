using CoffeeCorner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CoffeeCorner.Application.Features.Authentication.RegisterUser;

public class RegisterUserHandler(UserManager<User> userManager) : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            Name = request.Name ?? string.Empty,
            Surname = request.Surname ?? string.Empty,
            PublicId = Guid.NewGuid()
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

        return user.PublicId;
    }
}
