using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Exceptions;

public sealed class CharacteristicCreationException(string message) : DomainException(message);