using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Exceptions;

public sealed class CharacteristicValueException(string message) : DomainException(message);