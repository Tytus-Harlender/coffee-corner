namespace CoffeeCorner.Orders.Domain;

public enum OrderStatus
{
    Created = 0,
    PendingPayment = 1,
    Paid = 2,
    Processing = 3,
    Shipped = 4,
    InTransit = 5,
    OutForDelivery = 6,
    Delivered = 7,
    Completed = 8,
    Cancelled = 9,
    Failed = 10,
    ReturnRequested = 11,
    Returned = 12,
    Refunded = 13,
    OnHold = 14
}