using System.Linq.Expressions;
using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Customers.Application;

namespace CoffeeCorner.Infrastructure.Mapping.Customer;

public static class CustomerProjections
{
    public static Expression<Func<Customers.Domain.Entities.Customer, CustomerDto>> ToUserDto()
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