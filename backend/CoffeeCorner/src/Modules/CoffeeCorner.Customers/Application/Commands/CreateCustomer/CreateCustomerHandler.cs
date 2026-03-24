using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers.Domain.Entities;
using MediatR;

namespace CoffeeCorner.Customers.Application.Commands.CreateCustomer;

public class CreateCustomerHandler(ICustomerRepository customerRepository) : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken ct)
    {
        var customer = new Customer(request.PublicId, request.Name, request.Surname, request.Email);
        
        var newUserId = await customerRepository.CreateCustomerAsync(customer, ct);

        return new CustomerDto()
        {
            PublicId = newUserId,
            Email = "",
            Name = "",
            Surname = ""
        };
    }
}