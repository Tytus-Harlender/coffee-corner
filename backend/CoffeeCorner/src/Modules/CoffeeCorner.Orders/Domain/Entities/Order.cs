using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Orders.Domain.Entities;

public class Order(int customerId) : BaseEntity
{
    private readonly List<OrderItem> _items = [];
    public Guid OrderPublicId { get; init; } = Guid.NewGuid();
    public OrderStatus Status { get; private set; } = OrderStatus.Created;
    public decimal TotalAmount { get; private set; } =  decimal.Zero;

    public IReadOnlyCollection<OrderItem> Items => _items;
    public int CustomerId { get; init; } = customerId;
    
    internal void AddItem(OrderItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (item.Quantity <= 0)
        {
            throw new Exception("Item quantity cannot be less then 1");
        }
        
        if (_items.Any(x => x.ProductId == item.ProductId))
            throw new Exception("Duplicate product");

        _items.Add(item);
        RecalculateTotalAmount();
    }

    private void RecalculateTotalAmount()
    {
        TotalAmount = _items.Sum(i => i.Quantity * i.UnitPrice);
    }
}