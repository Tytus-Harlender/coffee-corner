using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Exceptions;

public sealed class StockDecreaseException(string message) : DomainException(message);