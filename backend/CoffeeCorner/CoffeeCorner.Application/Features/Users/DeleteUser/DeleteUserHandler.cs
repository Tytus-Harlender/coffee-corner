using MediatR;

namespace CoffeeCorner.Application.Features.Users.DeleteUser;

public class DeleteUserHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Task>
{
    public Task<Task> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(userRepository.DeleteUserAsync(request));
    }
}
