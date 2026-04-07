using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Basket.Domain.Entities;

public sealed class Basket : BaseEntity
{
    public int CustomerId { get; init; }
    public ICollection<BasketItem> BasketItems { get; private set; } = [];

    public decimal GetTotalPrice()
    {
        return BasketItems.Sum(item => item.UnitPrice * item.Quantity);
    }

    public void AddItem(int productId, int quantity, decimal unitPrice)
    {
        var existingItem = BasketItems.FirstOrDefault(item => item.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Increase(quantity);
        }
        else
        {
            BasketItems.Add(new BasketItem(this, productId, quantity, unitPrice));
        }
    }

    public void AddItems(IEnumerable<(int productId, int quantity, decimal unitPrice)> items)
    {
        foreach (var (productId, quantity, unitPrice) in items)
        {
            AddItem(productId, quantity, unitPrice);
        }
    }

    public void DeleteItem(int productId)
    {
        var existingItem = BasketItems.FirstOrDefault(bi => bi.ProductId == productId);

        if (existingItem is null)
            throw new Exception("Unable to delete - no products with provided publicId within the basket");

        if (existingItem.Quantity > 1)
            existingItem.Decrease(1);
        else
            BasketItems.Remove(existingItem);
        
    }
}