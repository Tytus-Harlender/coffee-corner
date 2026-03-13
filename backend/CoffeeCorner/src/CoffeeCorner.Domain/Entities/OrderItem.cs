namespace CoffeeCorner.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    private OrderItem()
    {
        
    }

    public OrderItem(Order order, int productId, int  quantity, decimal unitPrice)
    {
        //validation to be added
        OrderId = order.Id;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
}
