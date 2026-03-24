using CoffeeCorner.Customers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeCorner.Customers;

public interface ICustomerReadDbContext
{
    DbSet<Customer> Customers { get; }
}