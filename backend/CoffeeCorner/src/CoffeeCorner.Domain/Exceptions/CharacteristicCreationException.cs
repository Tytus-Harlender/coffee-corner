namespace CoffeeCorner.Domain.Exceptions;

public sealed class CharacteristicCreationException(string message) : DomainException(message);