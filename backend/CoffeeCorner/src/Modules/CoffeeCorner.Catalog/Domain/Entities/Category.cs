using CoffeeCorner.Catalog.Domain.Exceptions;
using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Catalog.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public int? ParentCategoryId { get; private set; }
    public Category? ParentCategory { get; private set; }
    public ICollection<Category> SubCategories { get; private set; } = [];
    public ICollection<Product> Products  { get; private set; } = [];
    
    private Category()
    {
    }

    public Category(
        string name,
        Category? parent = null)
    {
        if (string.IsNullOrEmpty(name))
            throw new CategoryCreationException("Category name cannot be null or empty.");

        Name = name.Trim();

        if (parent is null) return;
        ParentCategory = parent;
        parent.SubCategories.Add(this);
    }
}