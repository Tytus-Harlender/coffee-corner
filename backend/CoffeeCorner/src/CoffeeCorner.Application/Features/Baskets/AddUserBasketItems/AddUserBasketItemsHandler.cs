using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Interfaces;
using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.AddUserBasketItems;

public class AddUserBasketItemsHandler(IBasketRepository basketRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddUserBasketItemsCommand, IEnumerable<BasketItemDto>>
{
    public async Task<IEnumerable<BasketItemDto>> Handle(AddUserBasketItemsCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasketAsync(request.UserPublicId);

        var products =
            await productRepository.GetProductsByPublicIdsAsync(request.Items.Select(i => i.ProductPublicId));
        
        foreach (var item in request.Items)
        {
            basket.AddItem(products[item.ProductPublicId].Id, item.Quantity, item.UnitPrice);
        }

        if (basket.Id == 0)
            await basketRepository.AddBasketAsync(basket);
        else
            await basketRepository.UpdateBasketAsync(basket);
        
        var productIds = basket.BasketItems
            .Select(bi => bi.ProductId)
            .Distinct()
            .ToList();

        var publicIds = await productRepository.GetProductsPublicIdsAsync(productIds);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return [.. basket.BasketItems.Select(bi => new BasketItemDto() { ProductPublicId = publicIds[bi.ProductId], Quantity = bi.Quantity, UnitPrice = bi.UnitPrice })];
    }
}
