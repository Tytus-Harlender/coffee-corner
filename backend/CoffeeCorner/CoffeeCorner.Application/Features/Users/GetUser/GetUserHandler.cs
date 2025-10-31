using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetUser;

public class GetUserHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, UserDto>
{
    public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetUserAsync(request.PublicId).Result;
        return Task.FromResult(new UserDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email });
    }
}
