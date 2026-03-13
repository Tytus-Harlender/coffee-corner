using CoffeeCorner.Application.Features.Products;
using CoffeeCorner.Application.Interfaces;
using MediatR;

namespace CoffeeCorner.Application.Features.Baskets.DeleteUserBasketItems;

public class DeleteUserBasketItemsHandler(IBasketRepository basketRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserBasketItemsCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserBasketItemsCommand request, CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetBasketAsync(request.UserPublicId);

        var product = productRepository.GetProductAsync(request.ProductPublicId);
        
        basket.DeleteItem(product.Id);

        await basketRepository.UpdateBasketAsync(basket);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
