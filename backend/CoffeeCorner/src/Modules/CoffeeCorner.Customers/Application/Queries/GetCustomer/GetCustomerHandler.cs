using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Queries.GetCustomer;

public class GetUserHandler(ICustomerRepository customerRepository) : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    public Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var user = customerRepository.GetCustomerAsync(request.PublicId).Result;
        return Task.FromResult(new CustomerDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email });
    }
}