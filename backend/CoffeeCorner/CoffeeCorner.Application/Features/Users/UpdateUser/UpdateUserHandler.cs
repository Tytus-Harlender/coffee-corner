using MediatR;

namespace CoffeeCorner.Application.Features.Users.UpdateUser;

public class UpdateUserHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, UserDto>
{
    public Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = userRepository.UpdateUserAsync(request).Result;

        return Task.FromResult(new UserDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email});
    }
}
