namespace CoffeeCorner.Application.Features.Orders;

public class OrderDto
{
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
}
