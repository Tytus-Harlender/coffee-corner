namespace CoffeeCorner.Domain.Entities;

public class Basket : BaseEntity
{
    public User User { get; set; } = null!;
    public ICollection<BasketItem> BasketItems { get; set; } = [];
}