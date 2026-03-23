using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
{
}