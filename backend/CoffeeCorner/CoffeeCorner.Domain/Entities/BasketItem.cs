namespace CoffeeCorner.Domain.Entities;

public class BasketItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public int BasketId { get; set; }
    public Product Product { get; set; } = null!;

    private BasketItem() { }
    public BasketItem(Basket basket, Product product, int quantity, decimal unitPrice)
    {
        BasketId = basket.Id;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
