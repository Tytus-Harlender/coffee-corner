using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetAllUsers;

public class GetAllUsersHandler(IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await userRepository.GetAllUsersAsync();

        return [.. result.Select(u => new UserDto() { PublicId = u.PublicId, Name = u.Name, Surname = u.Surname, Email = u.Email })];
    }
}
