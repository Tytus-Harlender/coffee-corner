namespace CoffeeCorner.Domain.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }


    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}
