namespace CoffeeCorner.Domain.Entities;

public class BasketItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; private set; }

    public int BasketId { get; private set; }
    public int ProductId { get; private set; }

    private BasketItem() { }
    public BasketItem(Basket basket, int productId, int quantity, decimal unitPrice)
    {
        BasketId = basket.Id;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
