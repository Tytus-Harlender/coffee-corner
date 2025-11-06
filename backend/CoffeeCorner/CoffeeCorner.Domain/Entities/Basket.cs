namespace CoffeeCorner.Domain.Entities;

public class Basket : BaseEntity
{
    public int UserId { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; } = [];

    public decimal GetTotalPrice()
    {
        return BasketItems.Sum(item => item.UnitPrice * item.Quantity);
    }

    public void AddItem(Product product, int quantity, decimal unitPrice)
    {
        ArgumentNullException.ThrowIfNull(product);

        var existingItem = BasketItems.FirstOrDefault(item => item.Product.Id == product.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            BasketItems.Add(new BasketItem(this, product, quantity, unitPrice));
        }
    }

    public void AddItems(IEnumerable<(Product product, int quantity, decimal unitPrice)> items)
    {
        foreach (var (product, quantity, unitPrice) in items)
        {
            AddItem(product, quantity, unitPrice);
        }
    }

    public void DeleteItem(Guid productPublicId)
    {
        var existingItem = BasketItems.Where(bi => bi.Product.PublicId == productPublicId).FirstOrDefault();

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