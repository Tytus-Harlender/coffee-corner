namespace CoffeeCorner.Domain.Entities;

public class Order : BaseEntity
{
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];
    public int UserId { get; set; }
}
