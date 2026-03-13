using CoffeeCorner.Application.Interfaces;
using MediatR;

namespace CoffeeCorner.Application.Features.Users.CreateUser;

public class CreateUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var newUserId = await unitOfWork.CustomerRepository.CreateCustomerAsync(request);

        return new CustomerDto()
        {
            PublicId = newUserId,
            Email = "",
            Name = "",
            Surname = ""
        };
    }
}