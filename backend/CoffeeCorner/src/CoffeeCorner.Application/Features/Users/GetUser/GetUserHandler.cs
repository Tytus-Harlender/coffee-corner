using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetUser;

public class GetUserHandler(ICustomerRepository customerRepository) : IRequestHandler<GetUserQuery, CustomerDto>
{
    public Task<CustomerDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = customerRepository.GetCustomerAsync(request.PublicId).Result;
        return Task.FromResult(new CustomerDto() { PublicId = user.PublicId, Name = user.Name, Surname = user.Surname, Email = user.Email });
    }
}
