using CoffeeCorner.Application.Abstractions.Modules.Basket;
using CoffeeCorner.Orders.Domain.Entities;

namespace CoffeeCorner.Orders.Domain.Factories;

public class OrderFactory : IOrderFactory
{
    public Order CreateOrderFromBasket(BasketDto basket, int customerDbId, IDictionary<Guid, int> productIds)
    {
        if (basket == null || !basket.BasketItems.Any())
            throw new ArgumentNullException(nameof(basket), "Basket cannot be null or empty.");
        
        var order = new Order(customerDbId);

        foreach (var item in basket.BasketItems)
        {
            var orderItem = new OrderItem(order, productIds[item.ProductPublicId], item.Quantity, item.UnitPrice);
            order.AddItem(orderItem);
        }
        
        return order;
    }
}