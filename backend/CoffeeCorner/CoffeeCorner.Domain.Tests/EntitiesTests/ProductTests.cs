using CoffeeCorner.Domain.Entities;
using CoffeeCorner.Domain.Exceptions;
using FluentAssertions;

namespace CoffeeCorner.Domain.Tests.EntitiesTests;

public class ProductTests
{
    #region ConstructorTests
    [Fact]
    public void Constructor_ValidDataProvided_ShouldCreateProductWithValidData()
    {
        // Act
        var categoryMock = new Category("'Morning delight' Company");
        var characteristicMock = new Characteristic("Customer rating");
        characteristicMock.AddValues(["5 stars", "4 stars"]);
        
        var product = new Product(
            Guid.NewGuid(),
            "Coffee",
            25m,
            10,
            "Nice coffee",
            "image.jpg",
            [categoryMock],
            characteristicMock.CharacteristicValues.ToList()
        );

        // Assert
        product.Name.Should().Be("Coffee");
        product.Price.Should().Be(25m);
        product.StockQuantity.Should().Be(10);
        product.Description.Should().Be("Nice coffee");
        product.ImageUrl.Should().Be("image.jpg");
        product.Categories.Count.Should().Be(1);
        product.Categories.FirstOrDefault()?.Name.Should().Be("'Morning delight' Company");
        product.CharacteristicValues.Count.Should().Be(2);
        product.CharacteristicValues.Select(cv => cv.Value).Should().BeEquivalentTo(["5 stars", "4 stars"]);
    }

    [Fact]
    public void Constructor_OptionalValuesAreNull_ShouldUseDefaults()
    {
        // Act
        var product = new Product(
            Guid.NewGuid(),
            "Coffee",
            12m,
            15
        );

        // Assert
        product.Description.Should().BeEmpty();
        product.ImageUrl.Should().BeEmpty();
        product.Categories.Should().NotBeNull();
        product.CharacteristicValues.Should().NotBeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_ProductNameIsInvalid_ShouldThrowProductCreationException(string invalidName)
    {
        // Act
        var act = () => new Product(Guid.NewGuid(), invalidName, 26m, 25);

        // Assert
        act.Should()
            .Throw<ProductCreationException>()
            .WithMessage("Product name cannot be null or empty");
    }

    [Theory]
    [InlineData(-25)]
    [InlineData(0)]
    public void Constructor_PriceIsNegative_ShouldThrowProductCreationException(decimal  price)
    {
        // Act
        var act = () => new Product(Guid.NewGuid(), "Coffee", price, 25);

        // Assert
        act.Should()
            .Throw<ProductCreationException>()
            .WithMessage("Price must be positive");
    }

    [Fact]
    public void Constructor_StockIsNegative_ShouldThrowProductCreationException()
    {
        // Act
        var act = () => new Product(Guid.NewGuid(), "Coffee", 20m, -100);

        // Assert
        act.Should()
            .Throw<ProductCreationException>()
            .WithMessage("Stock cannot be negative");
    }

    #endregion

    #region DecreaseStockTests

    [Fact]
    public void DecreaseStock_QuantityIsValid_ShouldReduceStock()
    {
        // Arrange
        var product = new Product(Guid.NewGuid(), "Coffee", 20m, 100);

        // Act
        product.DecreaseStock(3);

        // Assert
        product.StockQuantity.Should().Be(97);
    }

    [Theory]
    [InlineData(-25)]
    [InlineData(0)]
    public void DecreaseStock_QuantityIsZeroOrLess_ShouldThrowStockDecreaseException(int quantity)
    {
        // Arrange
        var product = new Product(Guid.NewGuid(), "Coffee", 20m, 100);

        // Act
        var act = () => product.DecreaseStock(quantity);

        // Assert
        act.Should()
            .Throw<StockDecreaseException>()
            .WithMessage("Quantity must be positive");
    }

    [Fact]
    public void DecreaseStock_StockIsInsufficient_ShouldThrowStockDecreaseException()
    {
        // Arrange
        var product = new Product(Guid.NewGuid(), "Coffee", 20m, 8);

        // Act
        var act = () => product.DecreaseStock(10);

        // Assert
        act.Should()
            .Throw<StockDecreaseException>()
            .WithMessage("Insufficient stock");
    }

    #endregion
}
