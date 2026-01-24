namespace CoffeeCorner.Domain.Exceptions;

public sealed class StockDecreaseException(string message) : DomainException(message);