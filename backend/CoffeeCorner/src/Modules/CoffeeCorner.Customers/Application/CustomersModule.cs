using CoffeeCorner.Application.Abstractions.Modules.Customers;

namespace CoffeeCorner.Customers.Application;

public class CustomersModule(ICustomerRepository customerRepository) : ICustomersModule
{
    public async Task<bool> ExistsAsync(Guid customerPublicId)
    {
        return await customerRepository.ExistsAsync(customerPublicId);
    }

    public async Task<int> GetCustomerDbIdAsync(Guid customerPublicId)
    {
        return await customerRepository.GetCustomerDbIdAsync(customerPublicId);
    }
}