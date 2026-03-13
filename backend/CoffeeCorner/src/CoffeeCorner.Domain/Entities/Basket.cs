namespace CoffeeCorner.Domain.Entities;

public class Basket : BaseEntity
{
    public int CustomerId { get; init; }
    public ICollection<BasketItem> BasketItems { get; set; } = [];

    public decimal GetTotalPrice()
    {
        return BasketItems.Sum(item => item.UnitPrice * item.Quantity);
    }

    public void AddItem(int productId, int quantity, decimal unitPrice)
    {
        var existingItem = BasketItems.FirstOrDefault(item => item.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
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

        if (existingItem != null)
        {
            if (existingItem.Quantity > 0)
            {
                existingItem.Quantity -= 1;
            }
        }
        else 
        {
            throw new Exception("Unable to delete - no products with provided publicId within the basket");
        }
    }
}