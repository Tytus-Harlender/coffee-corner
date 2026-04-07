using CoffeeCorner.Application.Abstractions.Modules.Basket;
using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using CoffeeCorner.Application.Abstractions.Modules.Customers;

namespace CoffeeCorner.Basket.Application.ModuleApi;

public class BasketModule(ICustomersModule customersModule, ICatalogModule catalogModule, IBasketRepository basketRepository) : IBasketModule
{
    public async Task<BasketDto?> GetBasketDataByCustomerIdAsync(Guid customerId, CancellationToken ct)
    {
        var customerDbId = await customersModule.GetCustomerDbIdAsync(customerId);

        if (customerDbId == 0)
            throw new Exception("The customer was not found.");
        
        var basket = await basketRepository.GetBasketAsync(customerDbId);

        if (basket is null)
            return null;
        
        var productsIds = new Dictionary<int, Guid>();

        foreach (var basketItem in basket.BasketItems)
        {
            var publicID = await catalogModule.GetProductPublicId(basketItem.ProductId);
            productsIds.Add(basketItem.ProductId, publicID);
        }
        
        return new BasketDto
        {
            CustomerPublicId = customerId,
            BasketItems = basket.BasketItems
                .Select(i => new BasketItemDto
                {
                    ProductPublicId = productsIds[i.ProductId],
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                })
                .ToList()
        };
    }

    public async Task ClearAsync(Guid customerId, CancellationToken ct)
    {
        var customerDbId = await customersModule.GetCustomerDbIdAsync(customerId);

        if (customerDbId == 0)
            throw new Exception("The customer was not found.");
        
        var basket = await basketRepository.GetBasketAsync(customerDbId, false);
        
        await basketRepository.ClearBasketAsync(basket);
    }
}