using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public required Guid PublicId { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
}