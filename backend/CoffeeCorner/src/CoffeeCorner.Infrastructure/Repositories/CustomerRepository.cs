using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers;
using CoffeeCorner.Customers.Application;
using CoffeeCorner.Customers.Application.Commands.DeleteCustomer;
using CoffeeCorner.Customers.Application.Commands.UpdateCustomer;
using CoffeeCorner.Customers.Domain.Entities;
using CoffeeCorner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Infrastructure.Repositories;

public class CustomerRepository(CoffeeCornerDbContext context) : ICustomerRepository
{
    public async Task<bool> ExistsAsync(Guid customerPublicId)
    {
        var customers = await context.Customers
            .AnyAsync(c => c.PublicId == customerPublicId);
        return customers;
    }

    public async Task<int> GetCustomerDbIdAsync(Guid customerPublicId)
    {
        var customerInternalId = await context.Customers
            .AsNoTracking()
            .Where(i => i.PublicId == customerPublicId)
            .Select(i => i.Id)
            .FirstOrDefaultAsync();
        
        return customerInternalId;
    }

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

    public async Task<Guid> CreateCustomerAsync(Customer customer, CancellationToken ct = default)
    {
        if (customer is null)
            throw new Exception(message: "Customer entity is null");

        await context.Customers.AddAsync(customer, ct);
        await context.SaveChangesAsync(ct);

        return customer.PublicId;
    }

    public async Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerCommand command)
    {
        var user = await context.Customers
            .FirstOrDefaultAsync(u => u.PublicId == command.PublicId);

        if (user is not null)
        {
            //user.Name = string.IsNullOrWhiteSpace(command.Name) ? user.Name : command.Name;
            //user.Surname = string.IsNullOrWhiteSpace(command.Surname) ? user.Surname : command.Surname;
            //user.Email = string.IsNullOrWhiteSpace(command.Email) ? user.Email : command.Email;
            //user.PhoneNumber = command.PhoneNumber ?? user.PhoneNumber;
            //user.AddressLine1 = command.AddressLine1 ?? user.AddressLine1;
            //user.AddressLine2 = command.AddressLine2 ?? user.AddressLine2;
            //user.City = command.City ?? user.City;
            //user.Country = command.Country ?? user.Country;
            //user.UpdatedAt = DateTime.UtcNow;

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

    public async Task DeleteCustomerAsync(DeleteCustomerCommand command)
    {
        var user = await context.Customers
            .FirstOrDefaultAsync(u => u.PublicId == command.PublicId) ?? throw new Exception("User not found for the provided publicId value");

        user.IsDeleted = true;

        await context.SaveChangesAsync();
    }
}
