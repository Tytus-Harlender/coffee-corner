namespace CoffeeCorner.Domain.Exceptions;

public sealed class CustomerCreationException(string message) : DomainException(message);