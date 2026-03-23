using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Customers.Application.Queries.GetCustomer;

public class GetCustomerQuery(Guid publicId) : IRequest<CustomerDto>
{
    public Guid PublicId { get; set; } = publicId;
}