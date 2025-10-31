using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class UserRepository(CoffeeCornerDbContext context) : IUserRepository
{
    public async Task<Guid> CreateUserAsync(CreateUserCommand command)
    {
        if (command is null)
            throw new Exception(message: "Input parameters for user creation are null");

        var newUser = new User
        {
            PublicId = Guid.NewGuid(),
            Name = command.Name,
            Surname = command.Surname,
            Email = command.Password,
            PasswordHash = string.Empty,
        };

        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();

        return newUser.PublicId;
    }

    public async Task<User> GetUserByPublicId(Guid publicId)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.PublicId == publicId);

        return user is null ? new User() : user;
    }
}
