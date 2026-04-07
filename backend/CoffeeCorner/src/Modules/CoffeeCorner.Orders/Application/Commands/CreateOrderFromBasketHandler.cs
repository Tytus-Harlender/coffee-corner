using CoffeeCorner.Application.Abstractions.Modules.Basket;
using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Orders.Domain.Factories;
using MediatR;

namespace CoffeeCorner.Orders.Application.Commands;

public class CreateOrderFromBasketHandler(IBasketModule basketModule, ICatalogModule catalogModule, ICustomersModule customersModule, IOrderRepository orderRepository, IOrderFactory orderFactory) : IRequestHandler<CreateOrderFromBasketCommand, OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderFromBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketModule.GetBasketDataByCustomerIdAsync(request.CustomerPublicId, cancellationToken) ?? throw new Exception("Basket not found");
        
        var customerDbId = await customersModule.GetCustomerDbIdAsync(request.CustomerPublicId);

        var productIds = await catalogModule.GetProductDbIdsAsync(basket.BasketItems.Select(bi => bi.ProductPublicId));
        
        var order = orderFactory.CreateOrderFromBasket(basket, customerDbId, productIds);

        await orderRepository.AddAsync(order);
        
        await basketModule.ClearAsync(request.CustomerPublicId, cancellationToken);

        return new OrderDto()
        {
            OrderPublicId = order.OrderPublicId,
            Status =  order.Status.ToString(),
            TotalAmount = order.TotalAmount
        };
    }
}