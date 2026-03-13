using CoffeeCorner.Application.Features.Users;
using CoffeeCorner.Application.Features.Users.CreateUser;
using CoffeeCorner.Application.Features.Users.DeleteUser;
using CoffeeCorner.Application.Features.Users.UpdateUser;
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Infrastructure.Mapping.Customer;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class CustomerRepository(CoffeeCornerDbContext context) : ICustomerRepository
{
    public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
    {
        var users = await context.Customers
            .Select(CustomerProjections.ToUserDto())
            .ToListAsync();

        return users;
    }

    public async Task<CustomerDto> GetCustomerAsync(Guid publicId)
    {
        var user = await context.Customers
            .Where(u => u.PublicId == publicId)
            .Select(CustomerProjections.ToUserDto())
            .SingleOrDefaultAsync();

        return user ?? throw new Exception("User not found for the provided publicId value");
    }

    public async Task<Guid> CreateCustomerAsync(CreateCustomerCommand command)
    {
        if (command is null)
            throw new Exception(message: "Input parameters for user creation are null");

        var newCustomer = new Customer(command.Name, command.Surname, command.Email)
        {
            PublicId = Guid.NewGuid()
        };

        await context.Customers.AddAsync(newCustomer);
        await context.SaveChangesAsync();

        return newCustomer.PublicId;
    }

    public async Task<CustomerDto> UpdateCustomerAsync(UpdateUserCommand command)
    {
        var user = await context.Customers
            .FirstOrDefaultAsync(u => u.PublicId == command.PublicId);

        if (user is not null)
        {
            user.Name = string.IsNullOrWhiteSpace(command.Name) ? user.Name : command.Name;
            user.Surname = string.IsNullOrWhiteSpace(command.Surname) ? user.Surname : command.Surname;
            user.Email = string.IsNullOrWhiteSpace(command.Email) ? user.Email : command.Email;
            user.PhoneNumber = command.PhoneNumber ?? user.PhoneNumber;
            user.AddressLine1 = command.AddressLine1 ?? user.AddressLine1;
            user.AddressLine2 = command.AddressLine2 ?? user.AddressLine2;
            user.City = command.City ?? user.City;
            user.Country = command.Country ?? user.Country;
            user.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            //Add mapper 
            return new CustomerDto()
            {
                PublicId = user.PublicId,
                Email = "",
                Name = "",
                Surname = ""
            };
        }
        else
        {
            throw new Exception("User not found for the provided publicId value");
        }
    }

    public async Task DeleteCustomerAsync(DeleteUserCommand command)
    {
        var user = await context.Customers
            .FirstOrDefaultAsync(u => u.PublicId == command.PublicId) ?? throw new Exception("User not found for the provided publicId value");

        user.IsDeleted = true;

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllUserOrdersAsync(Guid userPublicId)
    {
        var user = await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.PublicId == userPublicId) ?? throw new Exception("User not found for the provided publicId value");
        
        var userOrders = await context.Orders
            .AsNoTracking()
            .Where(o => o.CustomerId == user.Id)
            .ToListAsync();

        if (userOrders.Count == 0)
            throw new Exception("No orders found for the user");

        return userOrders;
    }
}
