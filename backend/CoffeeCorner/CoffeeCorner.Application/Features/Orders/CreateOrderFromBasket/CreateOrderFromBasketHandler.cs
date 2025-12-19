using CoffeeCorner.Application.Features.Baskets;
using CoffeeCorner.Domain.Factories;
using MediatR;

namespace CoffeeCorner.Application.Features.Orders.CreateOrderFromBasket;

public class CreateOrderFromBasketHandler(IBasketRepository basketRepository, IOrderFactory orderFactory) : IRequestHandler<CreateOrderFromBasketCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderFromBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetUserBasketAsync(request.BasketPublicId) ?? throw new Exception("Basket not found");

        var order = orderFactory.CreateOrderFromBasket(basket);

        await basketRepository.DeleteBasketAsync(basket);

        return new OrderDto();
    }
}
