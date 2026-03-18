namespace CoffeeCorner.Application.Abstractions.Modules.Customers;

public interface ICustomersModule
{
    Task<bool> ExistsAsync(Guid customerPublicId);
    Task<int> GetCustomerDbIdAsync(Guid customerPublicId);
}