using CoffeeCorner.Application.Abstractions.Modules.Catalog;
using CoffeeCorner.Application.Abstractions.Modules.Customers;
using CoffeeCorner.Catalog.Application.ModuleApi;
using MediatR;

namespace CoffeeCorner.Basket.Application.Commands.DeleteCustomerBasketItems;

public class DeleteCustomerBasketItemsHandler(IBasketRepository basketRepository, ICustomersModule customersModule, ICatalogModule catalogModule) : IRequestHandler<DeleteCustomerBasketItemsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCustomerBasketItemsCommand request, CancellationToken cancellationToken)
    {
        var customerDbId = await customersModule.GetCustomerDbIdAsync(request.UserPublicId);
        
        if(customerDbId == 0)
            throw new Exception("Customer not found");
        
        var basket = await basketRepository.GetBasketAsync(customerDbId);

        var product = catalogModule.GetProductAsync(request.ProductPublicId);
        
        basket.DeleteItem(product.Id);

        await basketRepository.UpdateBasketAsync(basket);

        return Unit.Value;
    }
}