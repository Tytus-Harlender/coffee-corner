using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Commands.CreateCustomer;

public class CreateCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var newUserId = await customerRepository.CreateCustomerAsync(request);

        return new CustomerDto()
        {
            PublicId = newUserId,
            Email = "",
            Name = "",
            Surname = ""
        };
    }
}