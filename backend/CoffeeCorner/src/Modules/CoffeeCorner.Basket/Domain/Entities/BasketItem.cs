using CoffeeCorner.SharedKernel;

namespace CoffeeCorner.Basket.Domain.Entities;

public sealed class BasketItem : BaseEntity
{
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public int BasketId { get; private set; }
    public Basket Basket { get; private set; } = null!;
    public int ProductId { get; private set; }

    private BasketItem() { }
    public BasketItem(Basket basket, int productId, int quantity, decimal unitPrice)
    {
        Basket = basket;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
    
    public void Increase(int qty) => Quantity += qty;
    public void Decrease(int quantity)
    {
        if (Quantity <= 1) throw new Exception("Unable to decrease items quantity. Quantity must be greater than 0.");
        Quantity -= quantity;
    }
}