using MediatR;

namespace CoffeeCorner.Application.Features.Users.CreateUser;

public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, UserDto>
{
    public Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUserId = userRepository.CreateUserAsync(request);

        return Task.FromResult(new UserDto() { PublicId = newUserId.Result });
    }
}