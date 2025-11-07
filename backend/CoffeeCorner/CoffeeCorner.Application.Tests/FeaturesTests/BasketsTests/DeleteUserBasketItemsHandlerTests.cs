using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Application.Features.Baskets.DeleteUserBasketItems;
using CoffeeCorner.Application.Interfaces;
using CoffeeCorner.Domain.Entities;
using NSubstitute;

namespace CoffeeCorner.Application.Tests.FeaturesTests.BasketsTests;

public class DeleteUserBasketItemsHandlerTests
{
    [Fact]
    public void Handle_DeletesItemSuccessfully()
    {
        //Arrange
        var productPublicId = Guid.NewGuid();
        var basketRepository = Substitute.For<IBasketRepository>();
        var unitOfWork = Substitute.For<IUnitOfWork>();
        var command = new DeleteUserBasketItemsCommand(Guid.NewGuid(), productPublicId);
        var cancellationToken = new CancellationToken();
        var handler = new DeleteUserBasketItemsHandler(basketRepository, unitOfWork);

        var testingBasket = new Basket();
        List<BasketItem> basketItems = [ new(testingBasket, new Product() { PublicId = productPublicId }, 4, 11.99m)];
        basketRepository.GetUserBasketAsync(Arg.Any<Guid>(), Arg.Any<bool>())
            .Returns(new Basket() { BasketItems = basketItems});
        basketRepository.UpdateBasketAsync(Arg.Any<Basket>()).Returns(Task.CompletedTask);
        unitOfWork.SaveChangesAsync().Returns(Task.CompletedTask);

        //Act
        var result = handler.Handle(command, cancellationToken);

        //Assert
        Assert.NotNull(result);
        basketRepository.Received(1).UpdateBasketAsync(Arg.Any<Basket>());
        unitOfWork.Received(1).SaveChangesAsync();
    }
}
