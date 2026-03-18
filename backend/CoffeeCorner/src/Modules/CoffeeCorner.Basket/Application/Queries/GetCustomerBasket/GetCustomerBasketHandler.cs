using CoffeeCorner.Application.Abstractions.Modules.Basket;
using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Basket.Application.Queries.GetCustomerBasket;

public class GetCustomerBasketHandler(IBasketRepository basketRepository, ICustomersModule customersModule, ICatalogModule catalogModule) : IRequestHandler<GetCustomerBasketQuery, BasketDto>
{
    public async Task<BasketDto> Handle(GetCustomerBasketQuery request, CancellationToken cancellationToken)
    {
        
        var customerDbId = await customersModule.GetCustomerDbIdAsync(request.UserPublicId);
        
        if(customerDbId == 0)
            throw new Exception("Customer not found");
        
        var basket = await basketRepository.GetBasketAsync(customerDbId);
        
        var productIds = basket.BasketItems
            .Select(bi => bi.ProductId)
            .Distinct()
            .ToList();

        var publicIds = await catalogModule.GetProductsPublicIdsAsync(productIds);

        return basket == null ? throw new Exception($"Basket not found.") : new BasketDto() { CustomerPublicId = request.UserPublicId , BasketItems = [.. basket.BasketItems.Select(bi => new BasketItemDto() { ProductPublicId = publicIds[bi.ProductId], Quantity = bi.Quantity, UnitPrice = bi.UnitPrice})]};
    }
}