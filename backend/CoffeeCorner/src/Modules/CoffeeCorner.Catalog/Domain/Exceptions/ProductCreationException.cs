using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Exceptions;

public sealed class ProductCreationException(string message) : DomainException(message);