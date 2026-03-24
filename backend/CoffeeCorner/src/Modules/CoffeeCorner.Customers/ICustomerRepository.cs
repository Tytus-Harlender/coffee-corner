using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers.Application.Commands.CreateCustomer;
using CoffeeCorner.Customers.Application.Commands.DeleteCustomer;
using CoffeeCorner.Customers.Application.Commands.UpdateCustomer;
using CoffeeCorner.Customers.Domain.Entities;

namespace CoffeeCorner.Customers;

public interface ICustomerRepository
{
    public Task<int> GetCustomerDbIdAsync(Guid customerPublicId);
    public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    public Task<CustomerDto> GetCustomerAsync(Guid publicId);
    public Task<Guid> CreateCustomerAsync(Customer customer, CancellationToken ct = default);
    public Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerCommand command);
    public Task DeleteCustomerAsync(DeleteCustomerCommand command);
}