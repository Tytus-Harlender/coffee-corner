using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers.Application.Commands.CreateCustomer;
using CoffeeCorner.Customers.Application.Commands.DeleteCustomer;
using CoffeeCorner.Customers.Application.Commands.UpdateCustomer;
using CoffeeCorner.Orders;

namespace CoffeeCorner.Customers;

public interface ICustomerRepository
{
    public Task<bool> ExistsAsync(Guid customerPublicId);
    public Task<int> GetCustomerDbIdAsync(Guid customerPublicId);
    public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    public Task<CustomerDto> GetCustomerAsync(Guid publicId);
    public Task<Guid> CreateCustomerAsync(CreateCustomerCommand command);
    public Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerCommand command);
    public Task DeleteCustomerAsync(DeleteCustomerCommand command);
    public Task<IEnumerable<OrderDto>> GetAllUserOrdersAsync(Guid publicId);
}