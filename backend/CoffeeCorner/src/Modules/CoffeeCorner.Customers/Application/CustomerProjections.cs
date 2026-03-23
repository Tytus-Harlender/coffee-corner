using System.Linq.Expressions;
using CoffeeCorner.Application.Abstractions.Modules.Customers;

namespace CoffeeCorner.Customers.Application;

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