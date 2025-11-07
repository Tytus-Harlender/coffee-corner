using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Baskets.AddUserBasketItems;
using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Interfaces;
using CoffeeCorner.Domain.Entities;
using NSubstitute;

namespace CoffeeCorner.Application.Tests.FeaturesTests.BasketsTests;

public class AddUserBasketItemsHandlerTests
{
    [Fact]
    public void Handle_AddsItemSuccessfully()
    {
        //Arrange
        var basketRepository = Substitute.For<IBasketRepository>();
        var productRepository = Substitute.For<IProductRepository>();
        var unitOfWork = Substitute.For<IUnitOfWork>();
        var command = new AddUserBasketItemsCommand(Guid.NewGuid());
        var cancellationToken = new CancellationToken();
        var handler = new AddUserBasketItemsHandler(basketRepository, productRepository, unitOfWork);

        command.Items =
        [
            new()
            {
                ProductPublicId = Guid.NewGuid(),
                Quantity = 2,
                UnitPrice = 10.0m
            }
        ];
        basketRepository.GetUserBasketAsync(Arg.Any<Guid>(), Arg.Any<bool>())
            .Returns(new Basket() { Id = 0 });
        basketRepository.AddBasketAsync(Arg.Any<Basket>()).Returns(Task.CompletedTask);
        productRepository.GetProductAsync(Arg.Any<Guid>()).Returns(new Product() { Id = 1, PublicId = Guid.NewGuid(), Name = "Test Coffee", Price = 10.0m });
        unitOfWork.SaveChangesAsync().Returns(Task.CompletedTask);

        //Act
        var result = handler.Handle(command, cancellationToken);

        //Assert
        Assert.NotNull(result);
        basketRepository.Received(1).AddBasketAsync(Arg.Any<Basket>());
        unitOfWork.Received(1).SaveChangesAsync();
    }
}
