using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Commands.UpdateCustomer;

public class UpdateCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    public Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = customerRepository.UpdateCustomerAsync(request).Result;

        return Task.FromResult(new CustomerDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email});
    }
}