namespace CoffeeCorner.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public Basket Basket { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
