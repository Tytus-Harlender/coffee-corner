namespace CoffeeCorner.Domain.Exceptions;

public sealed class CharacteristicValueException(string message) : DomainException(message);