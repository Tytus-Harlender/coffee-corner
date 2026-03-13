namespace CoffeeCorner.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    private OrderItem()
    {
        
    }

    public OrderItem(Order order, Product product, int  quantity, decimal unitPrice)
    {
        //validation to be added
        OrderId = order.Id;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int OrderId { get; private set; }
    public Product Product { get; private set; } = null!;
}
