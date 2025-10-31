using MediatR;

namespace CoffeeCorner.Application.Features.Users;

public class GetUserByPublicIdHandler(IUserRepository userRepository) : IRequestHandler<GetUserByPublicIdQuery, UserDto>
{
    public Task<UserDto> Handle(GetUserByPublicIdQuery request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetUserByPublicId(request.PublicId).Result;
        return Task.FromResult(new UserDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email });
    }
}
