using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.GetUserBasket;

public class GetUserBasketHandler(IBasketRepository basketRepository) : IRequestHandler<GetUserBasketQuery, BasketDto>
{
    public async Task<BasketDto> Handle(GetUserBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetUserBasketAsync(request.UserPublicId);

        return basket == null ? throw new Exception($"Basket not found.") : new BasketDto() { UserPublicId = request.UserPublicId , BasketItems = [.. basket.BasketItems.Select(bi => new BasketItemDto() { ProductPublicId = bi.Product.PublicId, Quantity = bi.Quantity, UnitPrice = bi.UnitPrice})]};
    }
}
