using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
}
