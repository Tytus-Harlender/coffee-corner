using CoffeeCorner.Application.Features.Users.CreateUser;
using CoffeeCorner.Application.Features.Users.DeleteUser;
using CoffeeCorner.Application.Features.Users.UpdateUser;
using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Users;

public interface ICustomerRepository
{
    public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    public Task<CustomerDto> GetCustomerAsync(Guid publicId);
    public Task<Guid> CreateCustomerAsync(CreateCustomerCommand command);
    public Task<CustomerDto> UpdateCustomerAsync(UpdateUserCommand command);
    public Task DeleteCustomerAsync(DeleteUserCommand command);
    public Task<IEnumerable<Order>> GetAllUserOrdersAsync(Guid publicId);
}
