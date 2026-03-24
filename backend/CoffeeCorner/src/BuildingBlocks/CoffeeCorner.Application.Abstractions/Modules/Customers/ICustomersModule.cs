namespace CoffeeCorner.Application.Abstractions.Modules.Customers;

public interface ICustomersModule
{
    Task EnsureCustomerExistsAsync(CustomerDto customerPublicId, CancellationToken cancellationToken = default);
    Task<int> GetCustomerDbIdAsync(Guid customerPublicId);
}