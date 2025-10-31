using MediatR;

namespace CoffeeCorner.Application.Features.Users.DeleteUser;

public class DeleteUserCommand(Guid publicId) : IRequest<Task>
{
    public Guid PublicId { get; set; } = publicId;
}
