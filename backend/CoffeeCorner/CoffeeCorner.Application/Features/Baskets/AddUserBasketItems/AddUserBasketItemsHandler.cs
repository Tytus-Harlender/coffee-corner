using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Interfaces;
using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.AddUserBasketItems;

public class AddUserBasketItemsHandler(IBasketRepository basketRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddUserBasketItemsCommand, IEnumerable<BasketItemDto>>
{
    public async Task<IEnumerable<BasketItemDto>> Handle(AddUserBasketItemsCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetUserBasketAsync(request.UserPublicId);

        foreach (var item in request.Items)
        {
            var product = await productRepository.GetProductAsync(item.ProductPublicId);
            basket.AddItem(product, item.Quantity, item.UnitPrice);
        }

        if (basket.Id == 0)
            await basketRepository.AddBasketAsync(basket);
        else
            await basketRepository.UpdateBasketAsync(basket);

        await unitOfWork.SaveChangesAsync();
        return [.. basket.BasketItems.Select(bi => new BasketItemDto() { ProductPublicId = bi.Product.PublicId, Quantity = bi.Quantity, UnitPrice = bi.UnitPrice })];
    }
}
