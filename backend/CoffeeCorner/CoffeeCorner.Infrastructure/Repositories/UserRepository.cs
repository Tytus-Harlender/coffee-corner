using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Application.Features.Users.CreateUser;
using CoffeeCorner.Application.Features.Users.DeleteUser;
using CoffeeCorner.Application.Features.Users.UpdateUser;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class UserRepository(CoffeeCornerDbContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await context.Users
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<User> GetUserAsync(Guid publicId)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.PublicId == publicId);

        return user is null ? new User() : user;
    }

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

    public async Task<User> UpdateUserAsync(UpdateUserCommand command)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.PublicId == command.PublicId);

        if (user is not null)
        {
            user.Name = string.IsNullOrWhiteSpace(command.Name) ? user.Name : command.Name;
            user.Surname = string.IsNullOrWhiteSpace(command.Surname) ? user.Surname : command.Surname;
            user.Email = string.IsNullOrWhiteSpace(command.Email) ? user.Email : command.Email;
            user.PasswordHash = string.IsNullOrWhiteSpace(command.PasswordHash) ? user.PasswordHash : command.PasswordHash;
            user.PhoneNumber = command.PhoneNumber ?? user.PhoneNumber;
            user.AddressLine1 = command.AddressLine1 ?? user.AddressLine1;
            user.AddressLine2 = command.AddressLine2 ?? user.AddressLine2;
            user.City = command.City ?? user.City;
            user.Country = command.Country ?? user.Country;

            await context.SaveChangesAsync();

            return user;
        }
        else
        {
            throw new Exception("User not found for the provided publicId value");
        }
    }

    public async Task DeleteUserAsync(DeleteUserCommand command)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.PublicId == command.PublicId) ?? throw new Exception("User not found for the provided publicId value");

        user.IsDeleted = true;

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllUserOrdersAsync(Guid userPublicId)
    {
        var userOrders = await context.Orders
            .AsNoTracking()
            .Where(o => o.User.PublicId == userPublicId)
            .ToListAsync();

        if (userOrders.Count == 0)
            throw new Exception("No orders found for the user");

        return userOrders;
    }
}
