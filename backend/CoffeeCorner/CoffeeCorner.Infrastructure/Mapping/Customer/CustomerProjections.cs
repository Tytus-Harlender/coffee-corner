using System.Linq.Expressions;
using CoffeeCorner.Application.Features.Users;

namespace CoffeeCorner.Infrastructure.Mapping.Customer;

public static class CustomerProjections
{
    public static Expression<Func<Domain.Entities.Customer, CustomerDto>> ToUserDto()
    {
        return user => new CustomerDto()
        {
            PublicId = user.PublicId,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email ?? string.Empty
        };
    }
}