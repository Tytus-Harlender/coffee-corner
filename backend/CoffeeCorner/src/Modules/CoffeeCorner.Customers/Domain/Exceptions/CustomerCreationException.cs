using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Customers.Domain.Exceptions;

public sealed class CustomerCreationException(string message) : DomainException(message);