using CoffeeCorner.Application.Interfaces;
using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.GetUserBasket;

public class GetUserBasketHandler(IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IRequestHandler<GetUserBasketQuery, BasketDto>
{
    public async Task<BasketDto> Handle(GetUserBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetUserBasketAsync(request.UserPublicId);
        await unitOfWork.SaveChangesAsync();

        return basket == null ? throw new Exception($"Basket not found.") : new BasketDto() { UserPublicId = request.UserPublicId };
    }
}
