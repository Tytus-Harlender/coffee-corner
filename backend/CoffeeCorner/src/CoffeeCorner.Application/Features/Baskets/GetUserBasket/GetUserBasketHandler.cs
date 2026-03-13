using CoffeeCorner.Application.Features.Products;
using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.GetUserBasket;

public class GetUserBasketHandler(IBasketRepository basketRepository, IProductRepository productRepository) : IRequestHandler<GetUserBasketQuery, BasketDto>
{
    public async Task<BasketDto> Handle(GetUserBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasketAsync(request.UserPublicId);
        
        var productIds = basket.BasketItems
            .Select(bi => bi.ProductId)
            .Distinct()
            .ToList();

        var publicIds = await productRepository.GetProductsPublicIdsAsync(productIds);

        return basket == null ? throw new Exception($"Basket not found.") : new BasketDto() { UserPublicId = request.UserPublicId , BasketItems = [.. basket.BasketItems.Select(bi => new BasketItemDto() { ProductPublicId = publicIds[bi.ProductId], Quantity = bi.Quantity, UnitPrice = bi.UnitPrice})]};
    }
}
