using CoffeeCorner.Basket.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CoffeeCorner.Basket.Tests.UnitTests
{
    public class BasketItemTests
    {
        [Fact]
        public void BasketItem_Should_InitializeCorrectly()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };

            // Act
            var item = new BasketItem(basket, productId: 101, quantity: 3, unitPrice: 10m);

            // Assert
            item.Basket.Should().Be(basket);
            item.ProductId.Should().Be(101);
            item.Quantity.Should().Be(3);
            item.UnitPrice.Should().Be(10m);
        }

        [Fact]
        public void Increase_Should_AddToQuantity()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            var item = new BasketItem(basket, 101, 2, 10m);

            // Act
            item.Increase(3);

            // Assert
            item.Quantity.Should().Be(5);
        }

        [Fact]
        public void Decrease_Should_SubtractFromQuantity_WhenGreaterThanOne()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            var item = new BasketItem(basket, 101, 3, 10m);

            // Act
            item.Decrease(1);

            // Assert
            item.Quantity.Should().Be(2);
        }

        [Fact]
        public void Decrease_Should_Throw_WhenQuantityIsOneOrLess()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            var item = new BasketItem(basket, 101, 1, 10m);

            // Act
            Action act = () => item.Decrease(1);

            // Assert
            act.Should().Throw<Exception>()
               .WithMessage("Unable to decrease items quantity. Quantity must be greater than 0.");
        }

        [Fact]
        public void Decrease_Should_Throw_WhenTryingToDecreaseMoreThanCurrentQuantity()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            var item = new BasketItem(basket, 101, 2, 10m);

            // Act
            Action act = () => item.Decrease(2);

            // Assert
            act.Should().Throw<Exception>()
               .WithMessage("Unable to decrease items quantity. Quantity must be greater than 0.");
        }
    }
}