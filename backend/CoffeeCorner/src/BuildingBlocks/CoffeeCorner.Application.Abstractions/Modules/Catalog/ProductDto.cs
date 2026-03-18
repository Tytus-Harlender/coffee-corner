namespace CoffeeCorner.Application.Abstractions.Modules.Catalog;

public record ProductDto
{
    public Guid PublicId { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
}