namespace CoffeeCorner.Orders;

public record OrderDto
{
    public Guid OrderPublicId { get; set; }
    public string Status { get; init; } = string.Empty;
    public decimal TotalAmount { get; init; }
}