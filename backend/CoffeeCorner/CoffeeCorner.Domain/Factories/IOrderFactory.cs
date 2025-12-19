using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Domain.Factories;

public interface IOrderFactory
{
    Order CreateOrderFromBasket(Basket basket);
}
