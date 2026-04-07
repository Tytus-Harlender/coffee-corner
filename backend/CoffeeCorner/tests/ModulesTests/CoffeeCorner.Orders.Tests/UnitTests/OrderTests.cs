using CoffeeCorner.Orders.Domain;
using CoffeeCorner.Orders.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CoffeeCorner.Orders.Tests.UnitTests
{
    public class OrderTests
    {
        [Fact]
        public void Order_Should_InitializeCorrectly()
        {
            // Arrange & Act
            var order = new Order(customerId: 123);

            // Assert
            order.CustomerId.Should().Be(123);
            order.Status.Should().Be(OrderStatus.Created);
            order.TotalAmount.Should().Be(0m);
            order.Items.Should().BeEmpty();
            order.OrderPublicId.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public void AddItem_Should_AddItem_WhenValid()
        {
            // Arrange
            var order = new Order(customerId: 123);
            var item = new OrderItem(productId: 1, quantity: 2, unitPrice: 10m, order: order);

            // Act
            order.AddItem(item);

            // Assert
            order.Items.Should().ContainSingle();
            order.TotalAmount.Should().Be(20m);
        }

        [Fact]
        public void AddItem_Should_Throw_WhenItemIsNull()
        {
            // Arrange
            var order = new Order(customerId: 123);

            // Act
            Action act = () => order.AddItem(null!);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddItem_Should_Throw_WhenQuantityIsZeroOrNegative()
        {
            // Arrange
            var order = new Order(customerId: 123);
            var item = new OrderItem(productId: 1, quantity: 0, unitPrice: 10m, order: order);

            // Act
            Action act = () => order.AddItem(item);

            // Assert
            act.Should().Throw<Exception>()
               .WithMessage("Item quantity cannot be less then 1");
        }

        [Fact]
        public void AddItem_Should_Throw_WhenDuplicateProduct()
        {
            // Arrange
            var order = new Order(customerId: 123);
            var item1 = new OrderItem(productId: 1, quantity: 1, unitPrice: 10m, order: order);
            var item2 = new OrderItem(productId: 1, quantity: 2, unitPrice: 15m, order: order);

            order.AddItem(item1);

            // Act
            Action act = () => order.AddItem(item2);

            // Assert
            act.Should().Throw<Exception>()
               .WithMessage("Duplicate product");
        }

        [Fact]
        public void AddItem_Should_RecalculateTotalAmount_Correctly()
        {
            // Arrange
            var order = new Order(customerId: 123);
            var item1 = new OrderItem(productId: 1, quantity: 2, unitPrice: 10m, order: order);
            var item2 = new OrderItem(productId: 2, quantity: 3, unitPrice: 5m, order: order);

            // Act
            order.AddItem(item1);
            order.AddItem(item2);

            // Assert
            order.TotalAmount.Should().Be(2*10m + 3*5m); // 35m
            order.Items.Should().HaveCount(2);
        }
    }
}