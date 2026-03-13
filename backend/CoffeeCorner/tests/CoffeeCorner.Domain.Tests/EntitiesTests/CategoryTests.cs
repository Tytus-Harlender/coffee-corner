
using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Domain.Exceptions;
using FluentAssertions;

namespace CoffeeCorner.Domain.Tests.EntitiesTests;

public class CategoryTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Constructor_NameIsNullOrEmpty_ShouldThrowCategoryCreationException(string? name)
    {
        // Act
        var act = () => new Category(name!);

        // Assert
        act.Should().Throw<CategoryCreationException>()
            .WithMessage("Category name cannot be null or empty.");
    }

    [Fact]
    public void Constructor_ShouldTrimName()
    {
        var category = new Category("  Coffee  ");

        category.Name.Should().Be("Coffee");
    }

    [Fact]
    public void Constructor_WhenParentIsNull_ShouldCreateNoRootCategory()
    {
        var category = new Category("Coffee");

        category.ParentCategory.Should().BeNull();
        category.SubCategories.Should().BeEmpty();
    }

    [Fact]
    public void Constructor_WhenExistingParentIsProvided_ShouldSetParentCategory()
    {
        var parent = new Category("Beverages");
        var child = new Category("Coffee", parent);

        child.ParentCategory.Should().Be(parent);
        parent.SubCategories.Should().Contain(child);
    }

    [Fact]
    public void Constructor_WhenParentProvidedIsNull_ShouldNotSetParentCategory()
    {
        var child = new Category("Coffee", null);

        child.ParentCategory.Should().Be(null);
    }
}
