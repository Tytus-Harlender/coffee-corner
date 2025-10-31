using MediatR;

namespace CoffeeCorner.Application.Features.Users;

public class GetUserByPublicIdQuery(Guid publicId) : IRequest<UserDto>
{
    public Guid PublicId { get; set; } = publicId;
}