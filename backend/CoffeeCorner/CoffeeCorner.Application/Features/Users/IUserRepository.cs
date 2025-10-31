using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Application.Features.Users;

public interface IUserRepository
{
    public Task<User> GetUserByPublicId(Guid publicId);
    public Task<Guid> CreateUserAsync(CreateUserCommand command);
}
