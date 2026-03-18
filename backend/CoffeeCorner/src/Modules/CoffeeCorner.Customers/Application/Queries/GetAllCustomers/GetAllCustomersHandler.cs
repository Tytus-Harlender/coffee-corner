using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Queries.GetAllCustomers;

public class GetAllCustomersHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var result = await customerRepository.GetAllCustomersAsync();

        return [.. result.Select(u => new CustomerDto() { PublicId = u.PublicId, Name = u.Name, Surname = u.Surname, Email = u.Email })];
    }
}