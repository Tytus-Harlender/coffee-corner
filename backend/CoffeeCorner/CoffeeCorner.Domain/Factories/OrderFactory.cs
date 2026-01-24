using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Domain.Factories;

public class OrderFactory : IOrderFactory
{
    public Order CreateOrderFromBasket(Basket basket)
    {
        if (basket == null || basket.BasketItems.Count == 0)
            throw new ArgumentNullException(nameof(basket), "Basket cannot be null or empty.");

        var order = new Order();

        foreach (var item in basket.BasketItems)
        {
            var orderItem = new OrderItem(order,  item.Product, item.Quantity, item.UnitPrice);
            order.AddItem(orderItem);
        }

        return order;
    }
}
