namespace CoffeeCorner.Domain.Exceptions;

public sealed class ProductCreationException(string message) : DomainException(message);