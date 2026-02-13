using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetAllUsers;

public class GetAllUsersHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<CustomerDto>>
{
    public async Task<IEnumerable<CustomerDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await customerRepository.GetAllCustomersAsync();

        return [.. result.Select(u => new CustomerDto() { PublicId = u.PublicId, Name = u.Name, Surname = u.Surname, Email = u.Email })];
    }
}
