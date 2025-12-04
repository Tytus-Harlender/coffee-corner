using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoffeeCorner.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoffeeCorner.Application.Features.Authentication.AuthenticateUser;

public class AuthenticateUserHandler(UserManager<User> userManager, IConfiguration configuration) : IRequestHandler<AuthenticateUserCommand, string>
{
    public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = userManager.Users
            .FirstOrDefault(u => u.Email == request.Email);

        if (user == null)
            throw new Exception("User cannot be found");

        if (!await userManager.CheckPasswordAsync(user, request.Password))
            throw new Exception("Password does not match the specified user");

        return GenerateJwt(user);
    }

    private string GenerateJwt(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email ?? string.Empty),
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
