using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.GetUserBasket;

public class GetUserBasketQuery(Guid userPublicId) : IRequest<BasketDto>
{
    public Guid UserPublicId { get; set; } = userPublicId;
}
