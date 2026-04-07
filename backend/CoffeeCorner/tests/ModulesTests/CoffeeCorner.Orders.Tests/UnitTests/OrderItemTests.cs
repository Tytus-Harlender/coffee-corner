using CoffeeCorner.Orders.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CoffeeCorner.Orders.Tests.UnitTests
{
    public class OrderItemTests
    {
        [Fact]
        public void Constructor_Should_InitializePropertiesCorrectly()
        {
            // Arrange
            var order = new Order(customerId: 123);
            int productId = 1;
            int quantity = 5;
            decimal unitPrice = 10m;

            // Act
            var item = new OrderItem(order, productId, quantity, unitPrice);

            // Assert
            item.OrderId.Should().Be(order.Id);
            item.ProductId.Should().Be(productId);
            item.Quantity.Should().Be(quantity);
            item.UnitPrice.Should().Be(unitPrice);
        }

        [Fact]
        public void Constructor_Should_AllowZeroQuantity()
        {
            // Arrange
            var order = new Order(customerId: 123);

            // Act
            var item = new OrderItem(order, productId: 1, quantity: 0, unitPrice: 10m);

            // Assert
            item.Quantity.Should().Be(0);
            item.UnitPrice.Should().Be(10m);
        }

        [Fact]
        public void Constructor_Should_AssignCorrectOrderId_WhenMultipleItemsFromSameOrder()
        {
            // Arrange
            var order = new Order(customerId: 123);

            // Act
            var item1 = new OrderItem(order, productId: 1, quantity: 1, unitPrice: 5m);
            var item2 = new OrderItem(order, productId: 2, quantity: 2, unitPrice: 10m);

            // Assert
            item1.OrderId.Should().Be(order.Id);
            item2.OrderId.Should().Be(order.Id);
            item1.ProductId.Should().NotBe(item2.ProductId);
        }

        [Fact]
        public void PrivateConstructor_Should_Exist_ForEFCore()
        {
            // Arrange & Act
            var constructor = typeof(OrderItem).GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                               .FirstOrDefault(c => c.GetParameters().Length == 0);

            // Assert
            constructor.Should().NotBeNull("EF Core requires a private parameterless constructor");
        }
    }
}