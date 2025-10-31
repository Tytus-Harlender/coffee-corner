using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetUser;

public class GetUserQuery(Guid publicId) : IRequest<UserDto>
{
    public Guid PublicId { get; set; } = publicId;
}