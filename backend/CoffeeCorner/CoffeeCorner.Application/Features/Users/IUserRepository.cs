using CoffeeCorner.Application.Features.Users.CreateUser;
using CoffeeCorner.Application.Features.Users.DeleteUser;
using CoffeeCorner.Application.Features.Users.UpdateUser;
using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Users;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllUsersAsync();
    public Task<User> GetUserAsync(Guid publicId);
    public Task<Guid> CreateUserAsync(CreateUserCommand command);
    public Task<User> UpdateUserAsync(UpdateUserCommand command);
    public Task DeleteUserAsync(DeleteUserCommand command);
    public Task<IEnumerable<Order>> GetAllUserOrdersAsync(Guid publicId);
}
