namespace CoffeeCorner.Domain.Entities;

public class BasketItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Basket Basket { get; set; } = null!;
    public Product Product { get; set; } = null!;

    private BasketItem() { }
    public BasketItem(Basket basket, Product product, int quantity, decimal unitPrice)
    {
        Basket = basket;
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
