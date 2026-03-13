using MediatR;

namespace CoffeeCorner.Application.Features.Users.GetUser;

public class GetUserQuery(Guid publicId) : IRequest<CustomerDto>
{
    public Guid PublicId { get; set; } = publicId;
}