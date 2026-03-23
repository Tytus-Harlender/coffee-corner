using CoffeeCorner.Application.Abstractions.Modules.Basket;
using CoffeeCorner.Orders.Domain.Entities;

namespace CoffeeCorner.Orders.Domain.Factories;

public interface IOrderFactory
{
    Order CreateOrderFromBasket(BasketDto basket, int customerDbId, IDictionary<Guid, int> productIds);
}