namespace CoffeeCorner.Domain.Entities;

public class BasketItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; private set; }

    public int BasketId { get; private set; }
    public Product Product { get; private set; } = null!;

    private BasketItem() { }
    public BasketItem(Basket basket, Product product, int quantity, decimal unitPrice)
    {
        BasketId = basket.Id;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
