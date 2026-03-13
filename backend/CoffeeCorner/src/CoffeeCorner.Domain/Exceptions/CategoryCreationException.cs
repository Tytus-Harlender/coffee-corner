namespace CoffeeCorner.Domain.Exceptions;

public sealed class CategoryCreationException(string message) : DomainException(message);