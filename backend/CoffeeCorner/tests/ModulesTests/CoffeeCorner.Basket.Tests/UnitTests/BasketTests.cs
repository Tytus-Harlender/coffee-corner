using FluentAssertions;
using Xunit;

namespace CoffeeCorner.Basket.Tests.UnitTests
{
    public class BasketTests
    {
        [Fact]
        public void Basket_Should_HaveEmptyItems_OnCreation()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };

            // Act & Assert
            basket.BasketItems.Should().BeEmpty();
            basket.GetTotalPrice().Should().Be(0);
        }

        [Fact]
        public void AddItem_Should_AddNewItem_WhenNotExists()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };

            // Act
            basket.AddItem(productId: 101, quantity: 2, unitPrice: 10m);

            // Assert
            basket.BasketItems.Should().HaveCount(1);
            var item = basket.BasketItems.First();
            item.ProductId.Should().Be(101);
            item.Quantity.Should().Be(2);
            item.UnitPrice.Should().Be(10m);
            basket.GetTotalPrice().Should().Be(20m);
        }

        [Fact]
        public void AddItem_Should_IncreaseQuantity_WhenItemExists()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            basket.AddItem(productId: 101, quantity: 2, unitPrice: 10m);

            // Act
            basket.AddItem(productId: 101, quantity: 3, unitPrice: 10m);

            // Assert
            basket.BasketItems.Should().HaveCount(1);
            basket.BasketItems.First().Quantity.Should().Be(5);
            basket.GetTotalPrice().Should().Be(50m);
        }

        [Fact]
        public void AddItems_Should_AddMultipleItems()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            var items = new List<(int productId, int quantity, decimal unitPrice)>
            {
                (101, 2, 10m),
                (102, 1, 20m)
            };

            // Act
            basket.AddItems(items);

            // Assert
            basket.BasketItems.Should().HaveCount(2);
            basket.GetTotalPrice().Should().Be(40m);
        }

        [Fact]
        public void DeleteItem_Should_RemoveItem_WhenQuantityIsOne()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            basket.AddItem(101, 1, 10m);

            // Act
            basket.DeleteItem(101);

            // Assert
            basket.BasketItems.Should().BeEmpty();
            basket.GetTotalPrice().Should().Be(0);
        }

        [Fact]
        public void DeleteItem_Should_DecreaseQuantity_WhenQuantityMoreThanOne()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };
            basket.AddItem(101, 3, 10m);

            // Act
            basket.DeleteItem(101);

            // Assert
            var item = basket.BasketItems.First();
            item.Quantity.Should().Be(2);
            basket.GetTotalPrice().Should().Be(20m);
        }

        [Fact]
        public void DeleteItem_Should_Throw_WhenItemDoesNotExist()
        {
            // Arrange
            var basket = new Domain.Entities.Basket { CustomerId = 1 };

            // Act
            Action act = () => basket.DeleteItem(101);

            // Assert
            act.Should().Throw<Exception>()
               .WithMessage("Unable to delete - no products with provided publicId within the basket");
        }
    }
}