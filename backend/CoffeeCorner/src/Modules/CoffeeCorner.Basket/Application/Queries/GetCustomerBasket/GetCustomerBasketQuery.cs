using CoffeeCorner.Application.Abstractions.Modules.Basket;
using MediatR;

namespace CoffeeCorner.Basket.Application.Queries.GetCustomerBasket;

public class GetCustomerBasketQuery(Guid userPublicId) : IRequest<BasketDto>
{
    public Guid UserPublicId { get; set; } = userPublicId;
}