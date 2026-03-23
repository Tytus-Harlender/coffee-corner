using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Exceptions;

public sealed class CategoryCreationException(string message) : DomainException(message);