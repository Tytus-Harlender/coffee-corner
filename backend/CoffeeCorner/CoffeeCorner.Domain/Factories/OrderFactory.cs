using CoffeeCorner.Domain.Entities;

namespace CoffeeCorner.Domain.Factories;

public class OrderFactory : IOrderFactory
{
    public Order CreateOrderFromBasket(Basket basket)
    {
        if (basket == null || basket.BasketItems.Count == 0)
            throw new ArgumentNullException("Basket can be neither null nor empty");

        var order = new Order();

        foreach (var item in basket.BasketItems)
        {
            var orderItem = new OrderItem()
            {
                Quantity = item.Quantity,
                Product = item.Product,
                UnitPrice = item.UnitPrice,
                UpdatedAt = item.UpdatedAt,
                CreatedAt = item.CreatedAt,
                IsDeleted = item.IsDeleted,
            };
            order.AddItem(orderItem);
        }

        return order;
    }
}
