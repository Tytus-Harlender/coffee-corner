using MediatR;

namespace CoffeeCorner.Application.Features.Users.UpdateUser;

public class UpdateUserHandler(ICustomerRepository customerRepository) : IRequestHandler<UpdateUserCommand, CustomerDto>
{
    public Task<CustomerDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = customerRepository.UpdateCustomerAsync(request).Result;

        return Task.FromResult(new CustomerDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email});
    }
}
