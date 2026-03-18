using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using CoffeeCorner.Application.Abstractions.Modules.Customers;
using MediatR;

namespace CoffeeCorner.Basket.Application.Commands.AddCustomerBasketItems;

public class AddCustomerBasketItemsHandler(IBasketRepository basketRepository, ICustomersModule customersModule, ICatalogModule catalogModule) : IRequestHandler<AddCustomerBasketItemsCommand, IEnumerable<BasketItemDto>>
{
    public async Task<IEnumerable<BasketItemDto>> Handle(AddCustomerBasketItemsCommand request, CancellationToken cancellationToken)
    {
        var customerDbId = await customersModule.GetCustomerDbIdAsync(request.UserPublicId);
        
        var basket = await basketRepository.GetBasketAsync(customerDbId);

        var productsIds =
            await catalogModule.GetProductDbIdsAsync(request.Items.Select(i => i.ProductPublicId));
        
        foreach (var item in request.Items)
        {
            basket.AddItem(productsIds[item.ProductPublicId], item.Quantity, item.UnitPrice);
        }

        if (basket.Id == 0)
            await basketRepository.AddBasketAsync(basket);
        else
            await basketRepository.UpdateBasketAsync(basket);
        
        var productIds = basket.BasketItems
            .Select(bi => bi.ProductId)
            .Distinct()
            .ToList();

        var publicIds = await catalogModule.GetProductsPublicIdsAsync(productIds);
        
        return [.. basket.BasketItems.Select(bi => new BasketItemDto() { ProductPublicId = publicIds[bi.ProductId], Quantity = bi.Quantity, UnitPrice = bi.UnitPrice })];
    }
}