namespace CoffeeCorner.Domain.Entities;

public class Order : BaseEntity
{
    private readonly List<OrderItem> _items = [];
    public string Status { get; private set; } = string.Empty;
    public decimal TotalAmount { get; private set; } =  decimal.Zero;

    public IReadOnlyCollection<OrderItem> Items => _items;
    public int UserId { get; private set; }

    internal void AddItem(OrderItem item)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (item.Quantity <= 0)
        {
            throw new Exception("Item quantity cannot be less then 1");
        }

        _items.Add(item);
        RecalculateTotalAmount();
    }

    private void RecalculateTotalAmount()
    {
        TotalAmount = _items.Sum(i => i.Quantity * i.UnitPrice);
    }
}
