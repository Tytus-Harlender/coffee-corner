using MediatR;

namespace CoffeeCorner.Customers.Application.Commands.DeleteCustomer;

public class DeleteUserHandler(ICustomerRepository customerRepository) : IRequestHandler<DeleteCustomerCommand, Task>
{
    public Task<Task> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(customerRepository.DeleteCustomerAsync(request));
    }
}