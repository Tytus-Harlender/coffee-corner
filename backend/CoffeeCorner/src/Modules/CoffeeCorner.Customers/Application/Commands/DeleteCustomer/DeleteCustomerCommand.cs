using MediatR;

namespace CoffeeCorner.Customers.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommand(Guid publicId) : IRequest<Task>
{
    public Guid PublicId { get; set; } = publicId;
}