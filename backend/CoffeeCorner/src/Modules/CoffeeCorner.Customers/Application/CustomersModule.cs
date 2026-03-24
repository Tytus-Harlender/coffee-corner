using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Customers.Application;

public class CustomersModule(ICustomerRepository customerRepository, ICustomerReadDbContext readDbContext) : ICustomersModule
{
    public async Task EnsureCustomerExistsAsync(CustomerDto customerData, CancellationToken ct = default)
    {
        var exists = await readDbContext.Customers.AnyAsync(c => c.PublicId == customerData.PublicId, ct);

        if (exists)
            return;

        var customer = new Customer(
            customerData.PublicId,
            customerData.Name,
            customerData.Surname,
            customerData.Email
        );

        await customerRepository.CreateCustomerAsync(customer, ct);
    }

    public async Task<int> GetCustomerDbIdAsync(Guid customerPublicId)
    {
        return await customerRepository.GetCustomerDbIdAsync(customerPublicId);
    }
}