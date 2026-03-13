using MediatR;

namespace CoffeeCorner.Application.Features.Users.DeleteUser;

public class DeleteUserHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteUserCommand, Task>
{
    public Task<Task> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(customerRepository.DeleteCustomerAsync(request));
    }
}
